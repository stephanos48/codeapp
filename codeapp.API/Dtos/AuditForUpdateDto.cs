using System;

namespace codeapp.API.Dtos
{
    public class AuditForUpdateDto
    {

        public int AuditId { get; set; }

        public string AuditNo { get; set; }

        public int AuditTypeId { get; set; }

        public string AuditName { get; set; }

        public string AuditScope { get; set; }

        public DateTime PlannedAuditStartDate { get; set; }

        public DateTime PlannedAuditEndDate { get; set; }

        public DateTime ActualAuditStartDate { get; set; }

        public DateTime ActualAuditEndDate { get; set; }

        public string Auditors { get; set; }

        public string AuditReason { get; set; }

        public string AuditSummary { get; set; }

        public string Notes { get; set; }
        
    }
}