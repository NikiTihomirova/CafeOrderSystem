using System;

namespace CafeteriaOrderSystem.FactoryMethod
{
    public static class OrderFactory
    {
        public static IOrder CreateOrder(string type)
        {
            string loweredType = type.ToLower();

            if (loweredType == "coffee")
            {
                return new Coffee();
            }
            else if (loweredType == "tea")
            {
                return new Tea();
            }
            else if (loweredType == "juice")
            {
                return new Juice();
            }
            else if (loweredType == "lemonade")
            {
                return new Lemonade();
            }
            else
            {
                throw new ArgumentException("Невалиден тип напитка");
            }
        }
    }
}
