using System.Collections.Generic;

namespace codeapp.API.Models
{
    public class Responsible
    {
        
        public int ResponsibleId { get; set; }

        public string EmployeeName { get; set; }

        public string EmployeeTitle { get; set; }

        public string Notes { get; set; }



        public virtual ICollection<Scrum> Scrums  { get; set; }

    }
}