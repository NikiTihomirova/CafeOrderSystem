using System;
namespace CafeteriaOrderSystem.Observer
{
    public interface IOrderObserver
    {
        void Notify(string message);
    }
}
