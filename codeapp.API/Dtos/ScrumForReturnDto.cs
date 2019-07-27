using System;
using codeapp.API.Models;

namespace codeapp.API.Dtos
{
    public class ScrumForReturnDto
    {

        public int Id { get; set; }
        
        public string CreatedBy { get; set; }

        public DateTime DateCreated { get; set; }

        public int ResponsibleId { get; set; }

        public string Action { get; set; }

        public DateTime DueDate { get; set; }

        public DateTime CompletionDate { get; set; }

        public string Notes { get; set; }
        
    }
}