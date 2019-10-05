using System;
using System.ComponentModel.DataAnnotations;

namespace codeapp.API.Dtos
{
    public class FindingForCreationDto
    {
        
        public int FindingId { get; set; }

        public string IsoClauseProcess { get; set; }

        public int FindingTypeId { get; set; }

        public string FindingDetails { get; set;}

        public string Auditor { get; set; }

        public string Notes { get; set; }

    }
}