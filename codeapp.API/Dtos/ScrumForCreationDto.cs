using System;
using System.ComponentModel.DataAnnotations;
using codeapp.API.Models;

namespace codeapp.API.Dtos
{
    public class ScrumForCreationDto
    {
        public string CreatedBy { get; set; }

        public int ResponsibleId { get; set; }

        public string ScrumStatus { get; set; }

        public string Action { get; set; }

        public DateTime DueDate { get; set; }

        public DateTime CompletionDate { get; set; }

        public string ClosedStatus { get; set; }

        public string Notes { get; set; }

        public DateTime DateCreated { get; set; }

        public ScrumForCreationDto()
        {
            DateCreated = DateTime.Now;
        }
    }
}