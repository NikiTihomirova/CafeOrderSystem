using System;
using CafeteriaOrderSystem.FactoryMethod;

namespace CafeteriaOrderSystem.Decorator
{
    public class IceDecorator : OrderDecorator
    {
        public IceDecorator(IOrder order) : base(order)
        {
        }

        public override string GetDescription()
        {
            string originalDescription = _order.GetDescription();
            string updatedDescription = originalDescription + " + Лед";
            return updatedDescription;
        }

        public override double GetCost()
        {
            double originalCost = _order.GetCost();
            double updatedCost = originalCost + 0.20;
            return updatedCost;
        }

        public override void Prepare()
        {
            _order.Prepare();
            Console.WriteLine("Добавям лед...");
        }
    }
}
