using System;

namespace CafeteriaOrderSystem.FactoryMethod
{
    public class Juice : IOrder
    {
        public string GetDescription() => "Сок";
        public double GetCost() => 2.80;
        public void Prepare() => Console.WriteLine("Приготвям сок...");
    }
}
