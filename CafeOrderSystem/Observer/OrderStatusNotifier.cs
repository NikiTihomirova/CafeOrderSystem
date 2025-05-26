using System.Collections.Generic;
namespace CafeteriaOrderSystem.Observer
{
    public class OrderStatusNotifier
    {
        private readonly List<IOrderObserver> _observers = new();

        public void Subscribe(IOrderObserver observer) => _observers.Add(observer);
        public void Unsubscribe(IOrderObserver observer) => _observers.Remove(observer);

        public void NotifyAll(string message)
        {
            foreach (var observer in _observers)
                observer.Notify(message);
        }
    }
}