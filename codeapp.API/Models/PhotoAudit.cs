using System;

namespace codeapp.API.Models
{
    public class PhotoAudit
    {
        
        public int Id { get; set; }

        public string Url { get; set; }

        public string Description { get; set; }

        public DateTime DateAdded { get; set; }

        public bool IsMain { get; set; }

        public string PublicId { get; set; }

        public bool IsApproved { get; set; }

        public Audit Audit { get; set; }

        public int AuditId { get; set; }

    }
}