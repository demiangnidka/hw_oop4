using System;

namespace HW4._4
{
    public class Book : Product
    {
        public int PageCount { get; set; }
        public string Publisher { get; set; }
        public string Author { get; set; }

        public Book(decimal price, string countryOfOrigin, string name, DateTime manufactureDate, string description, int pageCount, string publisher, string author)
            : base(price, countryOfOrigin, name, manufactureDate, description)
        {
            PageCount = pageCount;
            Publisher = publisher;
            Author = author;
        }
    }
}