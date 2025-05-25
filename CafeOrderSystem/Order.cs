using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeOrderSystem
{
    public class Order
    {
        public string DrinkName { get; set; }
        public string PaymentMethod { get; set; }

        public Order(string drinkName, string paymentMethod)
        {
            DrinkName = drinkName;
            PaymentMethod = paymentMethod;
        }

        public override string ToString()
        {
            return $"Напитка: {DrinkName}, Плащане: {PaymentMethod}";
        }
    }
}

