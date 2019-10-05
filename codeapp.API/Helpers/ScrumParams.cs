namespace codeapp.API.Helpers
{
    public class ScrumParams
    {
        
        private const int MaxPageSize = 50;

        public int PageNumber {get; set; } = 1;

        private int pageSize = 10;

        public int PageSize
        {
            get { return pageSize; }
            set { pageSize = (value > MaxPageSize) ? MaxPageSize : value ;}
        }
        
        public int ScrumId { get; set; }

        public string ScrumStatus { get; set; }

        public string ClosedStatus { get; set; }

    }
}