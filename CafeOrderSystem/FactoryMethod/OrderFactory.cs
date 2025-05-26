using System;
namespace CafeteriaOrderSystem.FactoryMethod
{
    public static class OrderFactory
    {
        public static IOrder CreateOrder(string type)
        {
            return type.ToLower() switch
            {
                "coffee" => new Coffee(),
                "tea" => new Tea(),
                "juice" => new Juice(),
                "lemonade" => new Lemonade(),
                _ => throw new ArgumentException("Невалиден тип напитка")
            };
        }
    }
}
