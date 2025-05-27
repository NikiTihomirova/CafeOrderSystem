using System.Collections.Generic;

namespace CafeteriaOrderSystem.Observer
{
    public class OrderStatusNotifier
    {
        // Списък с наблюдатели, които ще получават известия
        private readonly List<IOrderObserver> _observers = new List<IOrderObserver>();

        // Метод за добавяне на нов наблюдател
        public void Subscribe(IOrderObserver observer)
        {
            _observers.Add(observer);
        }

        // Метод за премахване на наблюдател
        public void Unsubscribe(IOrderObserver observer)
        {
            _observers.Remove(observer);
        }

        // Метод за известяване на всички наблюдатели с дадено съобщение
        public void NotifyAll(string message)
        {
            foreach (IOrderObserver observer in _observers)
            {
                observer.Notify(message);
            }
        }
    }
}
