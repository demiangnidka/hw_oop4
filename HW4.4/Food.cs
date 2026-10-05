using System;

namespace HW4._4
{
    public class Food : Product
    {
        public DateTime ExpirationDate { get; set; }
        public int Quantity { get; set; }
        public string Unit { get; set; }

        public Food(decimal price, string countryOfOrigin, string name, DateTime packagingDate, string description, DateTime expirationDate, int quantity, string unit)
            : base(price, countryOfOrigin, name, packagingDate, description)
        {
            ExpirationDate = expirationDate;
            Quantity = quantity;
            Unit = unit;
        }
    }
}