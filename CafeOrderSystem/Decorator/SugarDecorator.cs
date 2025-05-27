using System;
using CafeteriaOrderSystem.FactoryMethod;

namespace CafeteriaOrderSystem.Decorator
{
    public class SugarDecorator : OrderDecorator
    {
        public SugarDecorator(IOrder order)
            : base(order)
        {
        }

        public override string GetDescription()
        {
            return _order.GetDescription() + " + Захар";
        }

        public override double GetCost()
        {
            return _order.GetCost() + 0.20;
        }

        public override void Prepare()
        {
            _order.Prepare();
            Console.WriteLine("Добавям захар...");
        }
    }
}
