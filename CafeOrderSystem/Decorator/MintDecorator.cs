using System;
using CafeteriaOrderSystem.FactoryMethod;

namespace CafeteriaOrderSystem.Decorator
{
    public class MintDecorator : OrderDecorator
    {
        public MintDecorator(IOrder order) : base(order) { }

        public override string GetDescription() => _order.GetDescription() + " + Мента";
        public override double GetCost() => _order.GetCost() + 0.30;
        public override void Prepare()
        {
            _order.Prepare();
            Console.WriteLine("Добавям мента...");
        }
    }
}
