using System;
using Microsoft.AspNetCore.Http;

namespace codeapp.API.Dtos
{
    public class PhotoAuditForCreationDto
    {
        
        public string Url { get; set; }

        public IFormFile File { get; set; }

        public string Description { get; set; }

        public DateTime DateAdded { get; set; }

        public string PublicId { get; set; }

        public PhotoAuditForCreationDto()
        {
            DateAdded = DateTime.Now;
        }

    }
}