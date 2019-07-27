namespace codeapp.API.Helpers
{
    public class CustomerParams
    {
        private const int MaxPageSize = 100;

        public int PageNumber {get; set; } = 1;

        private int pageSize = 50;

        public int PageSize
        {
            get { return pageSize; }
            set { pageSize = (value > MaxPageSize) ? MaxPageSize : value ;}
        }
        
        public int CustomerId { get; set; }

        public string Union { get; set; }

        public string Country { get; set; }

        public string OrderBy { get; set; }

    }
}