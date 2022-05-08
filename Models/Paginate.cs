namespace WebApplication3.Models
{
    public class Paginate
    {


        public int PageNumber { get; set; }

        private int _pageSize = 10; 

        public int PageSize
        {
            get { return _pageSize; }

            set { _pageSize = value; }


        }

    }
}
