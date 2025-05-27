using System;

namespace CafeteriaOrderSystem.FactoryMethod
{
    public class Tea : IOrder
    {
        public string GetDescription()
        {
            return "Чай";
        }

        public double GetCost()
        {
            return 2.50;
        }

        public void Prepare()
        {
            Console.WriteLine("Приготвям чай...");
        }
    }
}
