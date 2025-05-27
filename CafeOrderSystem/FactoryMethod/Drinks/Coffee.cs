using System;

namespace CafeteriaOrderSystem.FactoryMethod
{
    public class Coffee : IOrder
    {
        public string GetDescription()
        {
            return "Кафе";
        }

        public double GetCost()
        {
            return 3.00;
        }

        public void Prepare()
        {
            Console.WriteLine("Приготвям кафе...");
        }
    }
}
