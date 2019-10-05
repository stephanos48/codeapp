using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using codeapp.API.Dtos;
using codeapp.API.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using codeapp.API.Models;

namespace codeapp.API.Controllers
{

    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class NcrsController : ControllerBase
    {
        
        // private readonly IDatingRepository _repo;
        private readonly IDatingRepository _repo;
        private readonly IMapper _mapper;

        public NcrsController(IDatingRepository repo, IMapper mapper) 
        {
            _mapper = mapper;
            _repo = repo;
        }
        
        [HttpGet("getNcrs")]
        public async Task<IActionResult> GetNcrs()
        {

            var ncrs = await _repo.GetNcrs();

            var nrsToReturn = _mapper.Map<IEnumerable<NcrForReturnDto>>(ncrs);

/*             Response.AddPagination(customers.CurrentPage, customers.PageSize, 
                customers.TotalCount, customers.TotalPages); */

            return Ok(nrsToReturn);
        }
        
        [HttpGet("{id}", Name = "getNcr")]
        public async Task<IActionResult> GetNcr(int id)
        {
            var ncrFromRepo = await _repo.GetNcr(id);

            var ncrToReturn = _mapper.Map<NcrForReturnDto>(ncrFromRepo);

            return Ok(ncrToReturn);
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateNcr(int id, NcrForUpdateDto ncrForUpdateDto)
        {
            var ncrFromRepo = await _repo.GetNcr(id);

            _mapper.Map(ncrForUpdateDto, ncrFromRepo);

            if (await _repo.SaveAll())
                return NoContent();

            throw new Exception($"Updating user {id} failed on save");    
        }

        [HttpPost("createNcr")]
        public async Task<ActionResult> CreateNcr([FromBody]NcrForCreationDto ncrForCreationDto)
        {
            if (ModelState.IsValid)
            {
                var ncrToCreate = _mapper.Map<Ncr>(ncrForCreationDto);
                _repo.Add(ncrToCreate);

                if (await _repo.SaveChangesAsync())
                {
                var ncrToReturn = _mapper.Map<NcrForReturnDto>(ncrToCreate);
                return CreatedAtRoute("GetNcr", 
                        new { controller = "Ncrs", id = ncrToCreate.CustomerId }, ncrToReturn);
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