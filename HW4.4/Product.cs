using System;

namespace HW4._4
{
    public class Product
    {
        public decimal Price { get; set; }
        public string CountryOfOrigin { get; set; }
        public string Name { get; set; }
        public DateTime ManufactureDate { get; set; }
        public string Description { get; set; }

        public Product(decimal price, string countryOfOrigin, string name, DateTime manufactureDate, string description)
        {
            Price = price;
            CountryOfOrigin = countryOfOrigin;
            Name = name;
            ManufactureDate = manufactureDate;
            Description = description;
        }
    }
}