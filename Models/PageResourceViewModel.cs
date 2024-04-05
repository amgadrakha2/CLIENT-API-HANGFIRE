namespace ClientApp.Models
{
    public class PageResourceViewModel
    {
        const int maxPageSize = 50;
        public int PageNumber { get; set; } = 2;

        private int _pageSize = 10;
        public int PageSize
        {
            get { return _pageSize; }
            set { _pageSize = (value > maxPageSize) ? maxPageSize : value; }
        }

    }
}
