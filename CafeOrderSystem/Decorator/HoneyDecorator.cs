using CafeteriaOrderSystem.Decorator;
using CafeteriaOrderSystem.FactoryMethod;
using System;

namespace CafeOrderSystem.Decorator
{
    public class HoneyDecorator : OrderDecorator
    {
        public HoneyDecorator(IOrder order) : base(order)
        {
        }

        public override string GetDescription()
        {
            string originalDescription = _order.GetDescription();
            string updatedDescription = originalDescription + " + Мед";
            return updatedDescription;
        }

        public override double GetCost()
        {
            double originalCost = _order.GetCost();
            double updatedCost = originalCost + 0.50;
            return updatedCost;
        }

        public override void Prepare()
        {
            _order.Prepare();
            Console.WriteLine("Добавям мед...");
        }
    }
}
