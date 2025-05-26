using System;
using CafeteriaOrderSystem.FactoryMethod;

namespace CafeteriaOrderSystem.Decorator
{
    public class IceDecorator : OrderDecorator
    {
        public IceDecorator(IOrder order) : base(order) { }

        public override string GetDescription() => _order.GetDescription() + " + Лед";
        public override double GetCost() => _order.GetCost() + 0.20;
        public override void Prepare()
        {
            _order.Prepare();
            Console.WriteLine("Добавям лед...");
        }
    }
}
