using System;

namespace CafeOrderSystem.FactoryMethod
{
    public class Tea : IDrink
    {
        public string Name => "Чай";

        public decimal Price => 1.80m;

        public string Description => "Горещ чай с билки или черен чай";

        public void Prepare()
        {
            Console.WriteLine("Запарваме чай с гореща вода и сервираме.");
        }
    }
}
