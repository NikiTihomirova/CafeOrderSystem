using System;

namespace CafeteriaOrderSystem.FactoryMethod
{
    public class Lemonade : IOrder
    {
        public string GetDescription()
        {
            return "Лимонада";
        }

        public double GetCost()
        {
            return 3.00;
        }

        public void Prepare()
        {
            Console.WriteLine("Приготвям лимонада...");
        }
    }
}
