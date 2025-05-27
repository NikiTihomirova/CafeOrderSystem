using System;

namespace CafeteriaOrderSystem.FactoryMethod
{
    public class Juice : IOrder
    {
        public string GetDescription()
        {
            return "Сок";
        }

        public double GetCost()
        {
            return 2.80;
        }

        public void Prepare()
        {
            Console.WriteLine("Приготвям сок...");
        }
    }
}
