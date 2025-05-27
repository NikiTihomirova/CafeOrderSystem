using System;

namespace CafeteriaOrderSystem.Observer
{
    public interface IOrderObserver
    {
        //метода който известява със съобщенията
        void Notify(string message);
    }
}
