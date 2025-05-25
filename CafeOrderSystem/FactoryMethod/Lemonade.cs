using System;

namespace CafeOrderSystem.FactoryMethod
{
    public class Lemonade : IDrink
    {
        public string Name => "Лимонада";

        public decimal Price => 2.00m;

        public string Description => "Освежаваща лимонада с лед и резен лимон";

        public void Prepare()
        {
            Console.WriteLine("Смесваме лимонов сок, вода, захар и лед.");
        }
    }
}
