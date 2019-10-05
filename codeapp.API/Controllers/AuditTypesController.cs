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

    public class AuditTypesController : ControllerBase
    {
        private readonly IDatingRepository _repo;
        private readonly IMapper _mapper;

        public AuditTypesController(IDatingRepository repo, IMapper mapper) 
        {
            _mapper = mapper;
            _repo = repo;
        }

        [HttpGet("getAuditTypes")]
        public async Task<IActionResult> GetAuditTypes()
        {
            var auditTypes = await _repo.GetAuditTypes();

            var auditTypesToReturn = _mapper.Map<IEnumerable<AuditTypeForReturnDto>>(auditTypes);

            return Ok(auditTypesToReturn);
        }
        
    }
}