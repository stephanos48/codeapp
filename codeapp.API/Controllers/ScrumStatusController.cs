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

    public class ScrumStatusController : ControllerBase
    {
        private readonly IDatingRepository _repo;
        private readonly IMapper _mapper;

        public ScrumStatusController(IDatingRepository repo, IMapper mapper) 
        {
            _mapper = mapper;
            _repo = repo;
        }

        [HttpGet("getScrumStatus")]
        public async Task<IActionResult> GetSrumStatus()
        {
            var scrumstatus = await _repo.GetScrumStatus();

            var scrumStatusToReturn = _mapper.Map<IEnumerable<ResponsibleForReturnDto>>(scrumstatus);

            return Ok(scrumStatusToReturn);
        }
    }
}