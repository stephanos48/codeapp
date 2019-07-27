using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using codeapp.API.Data;
using codeapp.API.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace codeapp.API.Controllers
{

    [Authorize]
    [Route("api/[controller]")]
    [ApiController]

    public class ResponsiblesController : ControllerBase
    {
        private readonly IDatingRepository _repo;
        private readonly IMapper _mapper;

        public ResponsiblesController(IDatingRepository repo, IMapper mapper) 
        {
            _mapper = mapper;
            _repo = repo;
        }

        [HttpGet("getResponsibles")]
        public async Task<IActionResult> GetResponsibles()
        {
            var responsibles = await _repo.GetResponsibles();

            var responsiblesToReturn = _mapper.Map<IEnumerable<ResponsibleForReturnDto>>(responsibles);

            return Ok(responsiblesToReturn);
        }
        
    }
}