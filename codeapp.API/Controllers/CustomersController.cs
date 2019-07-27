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
    public class CustomersController : ControllerBase
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

        public CustomersController(IDatingRepository repo, IMapper mapper) 
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

        [HttpGet("getCustomers")]
        public async Task<IActionResult> GetCustomers()
        {

            var customers = await _repo.GetCustomers();

            var customersToReturn = _mapper.Map<IEnumerable<CustomerForReturnDto>>(customers);

/*             Response.AddPagination(customers.CurrentPage, customers.PageSize, 
                customers.TotalCount, customers.TotalPages); */

            return Ok(customersToReturn);
        }
        
        [HttpGet("{id}", Name = "getCustomer")]
        public async Task<IActionResult> GetCustomer(int id)
        {
            var customerFromRepo = await _repo.GetCustomer(id);

            var customerToReturn = _mapper.Map<CustomerForReturnDto>(customerFromRepo);

            return Ok(customerToReturn);
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomer(int id, CustomerForUpdateDto customerForUpdateDto)
        {
            var customerFromRepo = await _repo.GetCustomer(id);

            _mapper.Map(customerForUpdateDto, customerFromRepo);

            if (await _repo.SaveAll())
                return NoContent();

            throw new Exception($"Updating user {id} failed on save");    
        }

        [HttpPost("createCustomer")]
        public async Task<ActionResult> CreateCustomer([FromBody]CustomerForCreationDto customerForCreationDto)
        {
            if (ModelState.IsValid)
            {
                var customerToCreate = _mapper.Map<Customer>(customerForCreationDto);
                _repo.Add(customerToCreate);

                if (await _repo.SaveChangesAsync())
                {
                var customerToReturn = _mapper.Map<CustomerForReturnDto>(customerToCreate);
                return CreatedAtRoute("GetCustomer", 
                        new { controller = "Customers", id = customerToCreate.CustomerId }, customerToReturn);
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