using System;

namespace codeapp.API.Dtos
{
    public class CustomerForReturnDto
    {
        public int CustomerId { get; set; }

        public DateTime Created { get; set; }

        public string CustomerName { get; set; }

        public string Product { get; set; }

        public bool Union { get; set; }

        public string AnnualRevenue { get; set; }

        public string CompanyStart { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public string PhoneNo { get; set; }

        public string Email { get; set; }

        public string Website { get; set; }

        public string Notes { get; set; }
    }
}