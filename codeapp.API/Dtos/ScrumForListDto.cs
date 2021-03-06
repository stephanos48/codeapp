using System;

namespace codeapp.API.Dtos
{
    public class ScrumForListDto
    {
        public int Id { get; set; }
        
        public string CreatedBy { get; set; }

        public DateTime DateCreated { get; set; }

        public int ResponsibleId { get; set; }

        public string ScrumStatus { get; set; }

        public string Action { get; set; }

        public DateTime DueDate { get; set; }

        public DateTime CompletionDate { get; set; }

        public string ClosedStatus { get; set; }

        public string Notes { get; set; }
        

    }
}