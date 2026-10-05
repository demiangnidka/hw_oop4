using System;

namespace HW4._4
{
    public class Book : Product
    {
        public int PageCount { get; set; }
        public string Publisher { get; set; }
        public string Authors { get; set; }

        public Book(decimal price, string countryOfOrigin, string name, DateTime packagingDate, string description, int pageCount, string publisher, string authors)
            : base(price, countryOfOrigin, name, packagingDate, description)
        {
            PageCount = pageCount;
            Publisher = publisher;
            Authors = authors;
        }
    }
}