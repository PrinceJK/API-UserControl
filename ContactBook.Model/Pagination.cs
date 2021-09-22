using System.Collections.Generic;

namespace ContactBook.Model
{
    public class Pagination<T>
    {
        public int TotalNumberOfPages { get; set; }
        public int TotalNumberOfItems { get; set; }
        public int CurrentPage { get; set; }
        public int ItemsPerPage { get; set; }
        public ICollection<T> Items { get; set; }
    }
}
