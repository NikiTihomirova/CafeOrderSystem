using System;

namespace CafeteriaOrderSystem.FactoryMethod
{
    public class Tea : IOrder
    {
        public string GetDescription() => "Чай";
        public double GetCost() => 2.50;
        public void Prepare() => Console.WriteLine("Приготвям чай...");
    }
}
