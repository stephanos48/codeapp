using System;
using Microsoft.AspNetCore.Http;

namespace codeapp.API.Dtos
{
    internal class PhotoAuditForReturnDto
    {

        public int Id { get; set; }

        public string Url { get; set; }

        public string Description { get; set; }

        public DateTime DateAdded { get; set; }

        public bool IsMain { get; set; }

        public string PublicId { get; set; }

    }
}