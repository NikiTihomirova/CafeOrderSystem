using System;

namespace CafeOrderSystem.FactoryMethod
{
    public abstract class DrinkCreator
    {
        public abstract IDrink CreateDrink();

        public IDrink PrepareDrink()
        {
            IDrink drink = CreateDrink();
            drink.Prepare();
            return drink;
        }
    }

    public class CoffeeCreator : DrinkCreator
    {
        public override IDrink CreateDrink()
        {
            return new Coffee();
        }
    }

    public class TeaCreator : DrinkCreator
    {
        public override IDrink CreateDrink()
        {
            return new Tea();
        }
    }

    public class LemonadeCreator : DrinkCreator
    {
        public override IDrink CreateDrink()
        {
            return new Lemonade();
        }
    }

    public class JuiceCreator : DrinkCreator
    {
        public override IDrink CreateDrink()
        {
            return new Juice();
        }
    }

    public class DrinkFactory
    {
        public IDrink CreateDrink(string type)
        {
            if (type == null)
            {
                throw new ArgumentException("Типът на напитката не може да бъде null.");
            }

            string normalizedType = type.Trim().ToLower();
            DrinkCreator creator;

            if (normalizedType == "кафе")
            {
                creator = new CoffeeCreator();
            }
            else if (normalizedType == "чай")
            {
                creator = new TeaCreator();
            }
            else if (normalizedType == "лимонада")
            {
                creator = new LemonadeCreator();
            }
            else if (normalizedType == "сок")
            {
                creator = new JuiceCreator();
            }
            else
            {
                throw new ArgumentException($"Невалидна напитка: {type}. Моля, изберете от наличните опции.");
            }

            IDrink drink = creator.PrepareDrink();
            return drink;
        }

        public static string[] GetAvailableDrinks()
        {
            string[] drinks = new string[4];
            drinks[0] = "кафе";
            drinks[1] = "чай";
            drinks[2] = "лимонада";
            drinks[3] = "сок";

            return drinks;
        }
    }
}
