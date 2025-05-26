using System;

namespace CafeteriaOrderSystem.FactoryMethod
{
    public class Lemonade : IOrder
    {
        public string GetDescription() => "Лимонада";
        public double GetCost() => 3.00;
        public void Prepare() => Console.WriteLine("Приготвям лимонада...");
    }
}
