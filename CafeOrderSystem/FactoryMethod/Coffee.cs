using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeOrderSystem.FactoryMethod
{
    public class Coffee : IDrink
    {
        public string Name => "Кафе";
        public decimal Price => 2.50m;
        public string Description => "Прясно смляно ароматно кафе";

        public void Prepare()
        {
            Console.WriteLine("Приготвяне на кафе: Смилане на зърната → Загряване на вода → Приготвяне");
        }
    }
}

