using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using codeapp.API.Data;
using codeapp.API.Dtos;
using codeapp.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace codeapp.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ScrumsController : ControllerBase
    {
        private readonly IDatingRepository _repo;
        private readonly IMapper _mapper;

        public ScrumsController(IDatingRepository repo, IMapper mapper) 
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

        [HttpGet("getScrums")]
        public async Task<IActionResult> GetScrums()
        {

            var scrums = await _repo.GetScrums();

            var scrumsToReturn = _mapper.Map<IEnumerable<ScrumForReturnDto>>(scrums);

        /* Response.AddPagination(customers.CurrentPage, customers.PageSize, 
        customers.TotalCount, customers.TotalPages); */

            return Ok(scrumsToReturn);
        }
        
        [HttpGet("{id}", Name = "getScrum")]
        public async Task<IActionResult> GetScrum(int id)
        {
            var scrumFromRepo = await _repo.GetScrum(id);

            var scrumToReturn = _mapper.Map<ScrumForReturnDto>(scrumFromRepo);

            return Ok(scrumToReturn);
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateScrum(int id, ScrumForUpdateDto scrumForUpdateDto)
        {
            var scrumFromRepo = await _repo.GetScrum(id);

            _mapper.Map(scrumForUpdateDto, scrumFromRepo);

            if (await _repo.SaveAll())
                return NoContent();

            throw new Exception($"Updating user {id} failed on save");    
        }

        [HttpPost("createScrum")]
        public async Task<ActionResult> CreateScrum([FromBody]ScrumForCreationDto scrumForCreationDto)
        {
            if (ModelState.IsValid)
            {
                var scrumToCreate = _mapper.Map<Scrum>(scrumForCreationDto);
                _repo.Add(scrumToCreate);

                if (await _repo.SaveChangesAsync())
                {
                var scrumToReturn = _mapper.Map<ScrumForReturnDto>(scrumToCreate);
                return CreatedAtRoute("GetScrum", 
                        new { controller = "Scrums", id = scrumToCreate.Id }, scrumToReturn);
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