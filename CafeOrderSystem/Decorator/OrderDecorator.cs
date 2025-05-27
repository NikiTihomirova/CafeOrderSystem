using System;
using CafeteriaOrderSystem.FactoryMethod;

namespace CafeteriaOrderSystem.Decorator
{
    public abstract class OrderDecorator : IOrder
    {
        protected readonly IOrder _order;

        protected OrderDecorator(IOrder order)
        {
            _order = order;
        }

        public virtual string GetDescription()
        {
            return _order.GetDescription();
        }

        public virtual double GetCost()
        {
            return _order.GetCost();
        }

        public virtual void Prepare()
        {
            _order.Prepare();
        }
    }
}
