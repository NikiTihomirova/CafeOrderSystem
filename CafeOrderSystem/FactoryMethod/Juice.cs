using System;

namespace CafeOrderSystem.FactoryMethod
{
    public class Juice : IDrink
    {
        // Име на напитката
        public string Name => "Сок";

        // Цена на напитката
        public decimal Price => 2.20m;

        // Описание
        public string Description => "Прясно изцеден плодови сок";

        // Метод за приготвяне
        public void Prepare()
        {
            Console.WriteLine("Изцеждаме пресни плодове и сервираме със сняг.");
        }
    }
}
