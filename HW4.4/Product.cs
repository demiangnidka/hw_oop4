using System;

namespace HW4._4
{
    public class Product
    {
        public decimal Price { get; set; }
        public string CountryOfOrigin { get; set; }
        public string Name { get; set; }
        public DateTime PackagingDate { get; set; }
        public string Description { get; set; }

        public Product(decimal price, string countryOfOrigin, string name, DateTime packagingDate, string description)
        {
            Price = price;
            CountryOfOrigin = countryOfOrigin;
            Name = name;
            PackagingDate = packagingDate;
            Description = description;
        }
    }
}