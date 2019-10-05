using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.Configuration;
using codeapp.API.Data;
using codeapp.API.Dtos;
using codeapp.API.Helpers;
using codeapp.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace codeapp.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AuditController : ControllerBase
    {
        /*
        private readonly DataContext _context;
         
        public CustomersController(DataContext context)
        {
            _context = context;
        }
        */

        // private readonly IDatingRepository _repo;
        private readonly IDatingRepository _repo;
        private readonly IMapper _mapper;

        public AuditController(IDatingRepository repo, IMapper mapper) 
        {
            _mapper = mapper;
            _repo = repo;
        }

        /*
        // GET api/values
        [HttpGet("getCustomers")]
        public async Task<IActionResult> GetCustomers()
        {
            var customers = await _context.GetCustomers.ToListAsync();

            return Ok(customers);
        }
        */

        [HttpGet("getAudits")]
        public async Task<IActionResult> GetAudits()
        {

            var audits = await _repo.GetAudits();

            var auditsToReturn = _mapper.Map<IEnumerable<AuditForReturnDto>>(audits);

/*             Response.AddPagination(customers.CurrentPage, customers.PageSize, 
                customers.TotalCount, customers.TotalPages); */

            return Ok(auditsToReturn);
        }
        
        [HttpGet("{id}", Name = "getAudit")]
        public async Task<IActionResult> GetAudit(int id)
        {
            var auditFromRepo = await _repo.GetAudit(id);

            var auditToReturn = _mapper.Map<AuditForReturnDto>(auditFromRepo);

            return Ok(auditToReturn);
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAudit(int id, AuditForUpdateDto auditForUpdateDto)
        {
            var auditFromRepo = await _repo.GetAudit(id);

            _mapper.Map(auditForUpdateDto, auditFromRepo);

            if (await _repo.SaveAll())
                return NoContent();

            throw new Exception($"Updating user {id} failed on save");    
        }

        [HttpPost("createAudit")]
        public async Task<ActionResult> CreateAudit([FromBody]AuditForCreationDto auditForCreationDto)
        {
            if (ModelState.IsValid)
            {
                var auditToCreate = _mapper.Map<Audit>(auditForCreationDto);
                _repo.Add(auditToCreate);

                if (await _repo.SaveChangesAsync())
                {
                var auditToReturn = _mapper.Map<AuditForReturnDto>(auditToCreate);
                return CreatedAtRoute("GetAudit", 
                        new { controller = "Audit", id = auditToCreate.AuditId }, auditToReturn);
                }
                else
                {
                    return BadRequest("Failed to save changes to the database.");
                }   
            }

            return BadRequest(ModelState);

            /*if (await _repo.SaveAll()) {
                var customerToRetun = _mapper.Map<CustomerForReturnDto>(customer);
                return CreatedAtAction(nameof(GetCustomer), new { id = customer.CustomerId }, customerToRetun);
            }*/  
        }

        /*
        [HttpPost("editCustomer/{customerId}")]
        public async Task<IActionResult> Edit(int customerId, CustomerEditDto customerEditDto)
        {
            if (customerId != customerEditDto.CustomerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var customerToEdit = _mapper.Map<Customer>(customerEditDto);
                    _repo.Add(customerToEdit);
                    await _repo.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Customer(customerEditDto.CustomerId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return Ok(customerEditDto);
            }
            return Ok();
        }
        */

        /*
        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomer(int id)
        {
            var value = await _context.Customers.FirstOrDefaultAsync(x => x.CustomerId == id);

            return Ok(value);
        }
        */

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }


    }
}