using System;

namespace CafeteriaOrderSystem.Observer
{
    public class Barista : IOrderObserver
    {
        public string Name { get; }

        public Barista(string name) => Name = name;

        public void Notify(string message)
        {
            Console.WriteLine($"[Бариста {Name}] Получи известие: {message}");
        }
    }
}
