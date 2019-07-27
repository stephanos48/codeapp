using System;
using System.ComponentModel.DataAnnotations;

namespace codeapp.API.Dtos
{
    public class CustomerForCreationDto
    {
        [Required]
        public string CustomerName { get; set; }

        [Required]
        public string Product { get; set; }

        public bool Union { get; set; }

        public string AnnualRevenue { get; set; }

        public string CompanyStart { get; set; }

        public string Address { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string Country { get; set; }

        public string PhoneNo { get; set; }

        public string Email { get; set; }

        public DateTime Created { get; set; }

        public CustomerForCreationDto()
        {
            Created = DateTime.Now;
        }
    }
}