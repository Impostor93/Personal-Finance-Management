using System.Security.Cryptography.X509Certificates;
using System;

namespace PersonalFinanceManagement.Domain.Model
{
    public class Purchase
    {
        public CategoryId CategoryId { get; }

        public DateTime HappendOn { get; }

        public float Price { get; }

        public Purchase() {}
        
        public Purchase(CategoryId categoryId, DateTime happendOn, float price)
        {
            CategoryId = categoryId;
            HappendOn = happendOn;
            Price = price;
        }
    }
}
