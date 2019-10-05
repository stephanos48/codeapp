using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using codeapp.API.Data;
using codeapp.API.Dtos;
using codeapp.API.Helpers;
using codeapp.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace codeapp.API.Controllers
{

    [Route("api/audit/{auditId}/photoaudits")]
    [ApiController]
    public class PhotoAuditsController : ControllerBase
    {

        private readonly IDatingRepository _repo;

        private readonly IMapper _mapper;
        
        private readonly IOptions<CloudinarySettings> _cloudinaryConfig;

        private Cloudinary _cloudinary;

        public PhotoAuditsController(IDatingRepository repo, IMapper mapper, IOptions<CloudinarySettings> cloudinaryConfig)
        {
            _cloudinaryConfig = cloudinaryConfig;
            _mapper = mapper;
            _repo = repo;

            Account acc = new Account(
              _cloudinaryConfig.Value.CloudName,
              _cloudinaryConfig.Value.ApiKey,
              _cloudinaryConfig.Value.ApiSecret  
            );

            _cloudinary = new Cloudinary(acc);

        }

        [HttpGet("(id)", Name = "GetPhotoAudit")]
        public async Task<IActionResult> GetPhotoAudit(int id)
        {
            var photoAuditFromRepo = await _repo.GetPhotoAudit(id);

            var photo = _mapper.Map<PhotoAuditForReturnDto>(photoAuditFromRepo);

            return Ok(photo);
        }

        [HttpPost]
        public async Task<IActionResult> AddPhotoForAudit (int auditId, 
            [FromForm]PhotoAuditForCreationDto photoAuditForCreationDto)
        {

            var auditFromRepo = await _repo.GetAudit(auditId);

            var file = photoAuditForCreationDto.File;

            var uploadResult = new ImageUploadResult();

            if (file.Length > 0)
            {
                using (var stream = file.OpenReadStream())
                {
                    var uploadParams = new ImageUploadParams()
                    {
                        File = new FileDescription(file.Name, stream),
                        Transformation = new Transformation().Width(500).Height(500).Crop("fill").Gravity("face")
                    };

                    uploadResult = _cloudinary.Upload(uploadParams);
                }
            }

            photoAuditForCreationDto.Url = uploadResult.Uri.ToString();
            photoAuditForCreationDto.PublicId = uploadResult.PublicId;

            var photo = _mapper.Map<PhotoAudit>(photoAuditForCreationDto);

            if (!auditFromRepo.PhotoAudits.Any(u => u.IsMain))
                photo.IsMain = true;

            auditFromRepo.PhotoAudits.Add(photo);

            if (await _repo.SaveAll())
            {
                var photoAuditToReturn = _mapper.Map<PhotoAuditForReturnDto>(photo);
                return CreatedAtRoute("GetPhotoAudit", new { id = photo.Id }, photoAuditToReturn);
            }

            return BadRequest("Could not add the photo");
        }

        [HttpPost("{id}/setMain")]
        public async Task<IActionResult> SetMainPhoto(int auditId, int id)
        {

            var audit = await _repo.GetAudit(auditId);
            
            if (!audit.PhotoAudits.Any(p => p.Id == id))
                return Unauthorized();

            var photoAuditFromRepo = await _repo.GetPhotoAudit(id);

            if (photoAuditFromRepo.IsMain)
                return BadRequest("This is already the main photo");

            var currentMainPhoto = await _repo.GetMainPhotoForUser(auditId);
            currentMainPhoto.IsMain = false;
            
            photoAuditFromRepo.IsMain = true;

            if (await _repo.SaveAll())
                return NoContent();

            return BadRequest("Could not set photo to main");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePhotoAudit(int auditId, int id)
        {

            var audit = await _repo.GetAudit(auditId);
            
            if (!audit.PhotoAudits.Any(p => p.Id == id))
                return Unauthorized();

            var photoAuditFromRepo = await _repo.GetPhotoAudit(id);

            if (photoAuditFromRepo.IsMain)
                return BadRequest("You cannot delete your main photo");

            if (photoAuditFromRepo.PublicId != null)
            {            
                var deleteParams = new DeletionParams(photoAuditFromRepo.PublicId);

                var result = _cloudinary.Destroy(deleteParams);

                if (result.Result == "ok") {
                    _repo.Delete(photoAuditFromRepo);
                }
            }

            if (photoAuditFromRepo.PublicId == null)
            {
                _repo.Delete(photoAuditFromRepo);
            }

            if (await _repo.SaveAll())
                return Ok();

            return BadRequest("Failed to delete the photo");
        }
    }
}