using System;

namespace codeapp.API.Dtos
{
    public class FindingEditDto
    {  
        
        public int FindingId { get; set; }

        public string IsoClauseProcess { get; set; }

        public int FindingTypeId { get; set; }

        public string FindingDetails { get; set;}

        public string Auditor { get; set; }

        public string Notes { get; set; }
        
    }
}