using System;
namespace CafeteriaOrderSystem.FactoryMethod
{
    public class Coffee : IOrder
    {
        public string GetDescription() => "Кафе";
        public double GetCost() => 3.00;
        public void Prepare() => Console.WriteLine("Приготвям кафе...");
    }
}