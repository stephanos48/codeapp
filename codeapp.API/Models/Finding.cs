using System.Collections.Generic;

namespace codeapp.API.Models
{
    public class Finding
    {
        
        public int FindingId { get; set; }

        public string IsoClauseProcess { get; set; }

        public int FindingTypeId { get; set; }

        public string FindingDetails { get; set;}

        public string Auditor { get; set; }

        public string Notes { get; set; }

        public virtual FindingType FindingType { get; set; }

        public Audit Audit { get; set; }
        
    }
}