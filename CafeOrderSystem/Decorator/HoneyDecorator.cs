using CafeteriaOrderSystem.Decorator;
using CafeteriaOrderSystem.FactoryMethod;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeOrderSystem.Decorator
{
    public class HoneyDecorator : OrderDecorator
    {
        public HoneyDecorator(IOrder order) : base(order) { }

        public override string GetDescription() => _order.GetDescription() + " + Мед";
        public override double GetCost() => _order.GetCost() + 0.50;
        public override void Prepare()
        {
            _order.Prepare();
            Console.WriteLine("Добавям мед...");
        }
    }
}
