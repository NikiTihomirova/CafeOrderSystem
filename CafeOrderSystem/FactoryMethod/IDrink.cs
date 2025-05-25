using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeOrderSystem.FactoryMethod
{
    public interface IDrink
    {
        string Name { get; }
        decimal Price { get; }
        string Description { get; }
        void Prepare();
    }
}
