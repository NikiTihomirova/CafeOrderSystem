using System;

namespace CafeteriaOrderSystem.Observer
{
    public class Barista : IOrderObserver
    {
        private string _name;

        public string Name
        {
            get
            {
                return _name;
            }
        }

        public Barista(string name)
        {
            _name = name;
        }

        public void Notify(string message)
        {
            string output = "[Бариста " + _name + "] Получи известие: " + message;
            Console.WriteLine(output);
        }
    }
}
