using System;
using System.Collections.Generic;
using CafeteriaOrderSystem.FactoryMethod;
using CafeteriaOrderSystem.Decorator;
using CafeOrderSystem.Decorator;

namespace CafeteriaOrderSystem
{
    public class Program
    {
        // Точка за стартиране на програмата
        public static void Main()
        {
            RunSystem();
        }

        // Основен метод, който управлява менюто и взаимодействието с потребителя
        private static void RunSystem()
        {
            // Списък с текущи поръчани напитки
            List<IOrder> currentOrderItems = new List<IOrder>();

            // Безкраен цикъл за менюто
            while (true)
            {
                Console.WriteLine("\nМеню:");
                Console.WriteLine("1. Поръчай напитка");
                Console.WriteLine("2. Виж поръчката");
                Console.WriteLine("3. Премахни напитка");
                Console.WriteLine("4. Плащане");
                Console.WriteLine("0. Изход");
                Console.Write("Избор: ");

                string choice = Console.ReadLine();

                // Проверка за валидност на избора, премахване на празни пространства
                if (choice != null)
                {
                    choice = choice.Trim();
                }

                switch (choice)
                {
                    case "1":
                        IOrder orderItem = ChooseDrink();
                        if (orderItem != null)
                        {
                            orderItem = ChooseExtras(orderItem);
                            currentOrderItems.Add(orderItem);
                            Console.WriteLine("Напитката е добавена към поръчката.");
                        }
                        else
                        {
                            Console.WriteLine("Невалиден избор на напитка.");
                        }
                        break;

                    case "2":
                        ShowOrder(currentOrderItems);
                        break;

                    case "3":
                        RemoveItem(currentOrderItems);
                        break;

                    case "4":
                        FinalizeOrder(currentOrderItems);
                        break;

                    case "0":
                        Console.WriteLine("Излизане от системата. Приятен ден!");
                        return;

                    default:
                        Console.WriteLine("Невалидна команда. Моля, опитайте отново.");
                        break;
                }
            }
        }

        // Метод за избор на напитка от менюто
        private static IOrder ChooseDrink()
        {
            Console.WriteLine("\nИзберете напитка:");
            Console.WriteLine("1. Кафе");
            Console.WriteLine("2. Чай");
            Console.WriteLine("3. Сок");
            Console.WriteLine("4. Лимонада");
            Console.Write("Ваш избор: ");

            string input = Console.ReadLine();

            if (input != null)
            {
                input = input.Trim();
            }

            switch (input)
            {
                case "1":
                    return OrderFactory.CreateOrder("coffee");

                case "2":
                    return OrderFactory.CreateOrder("tea");

                case "3":
                    return OrderFactory.CreateOrder("juice");

                case "4":
                    return OrderFactory.CreateOrder("lemonade");

                default:
                    return null;
            }
        }

        // Метод за добавяне на допълнителни добавки към напитката
        private static IOrder ChooseExtras(IOrder order)
        {
            while (true)
            {
                Console.WriteLine("\nДобавки:");
                Console.WriteLine("1. Захар (+0.20 лв.)");
                Console.WriteLine("2. Мента (+0.30 лв.)");
                Console.WriteLine("3. Мед (+0.50 лв.)");
                Console.WriteLine("4. Лед (+0.20 лв.)");
                Console.WriteLine("0. Готово");
                Console.Write("Избор: ");

                string choice = Console.ReadLine();

                if (choice != null)
                {
                    choice = choice.Trim();
                }

                switch (choice)
                {
                    case "1":
                        order = new SugarDecorator(order);
                        Console.WriteLine("Добавката захар е добавена.");
                        break;

                    case "2":
                        order = new MintDecorator(order);
                        Console.WriteLine("Добавката мента е добавена.");
                        break;

                    case "3":
                        order = new HoneyDecorator(order);
                        Console.WriteLine("Добавката мед е добавена.");
                        break;

                    case "4":
                        order = new IceDecorator(order);
                        Console.WriteLine("Добавката лед е добавена.");
                        break;

                    case "0":
                        return order;

                    default:
                        Console.WriteLine("Невалиден избор. Моля, опитайте отново.");
                        break;
                }
            }
        }

        // Метод за показване на текущата поръчка и общата сума
        private static void ShowOrder(List<IOrder> items)
        {
            if (items.Count == 0)
            {
                Console.WriteLine("Поръчката е празна.");
                return;
            }

            Console.WriteLine("\nТекуща поръчка:");

            double total = 0;

            for (int i = 0; i < items.Count; i++)
            {
                string description = items[i].GetDescription();
                double cost = items[i].GetCost();

                Console.WriteLine($"{i + 1}. {description} - {cost:F2} лв.");

                total += cost;
            }

            Console.WriteLine($"Обща сума: {total:F2} лв.");
        }

        // Метод за премахване на напитка от поръчката по номер
        private static void RemoveItem(List<IOrder> items)
        {
            if (items.Count == 0)
            {
                Console.WriteLine("Няма какво да премахнете, поръчката е празна.");
                return;
            }

            Console.WriteLine("Изберете номер на напитка за премахване:");

            for (int i = 0; i < items.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {items[i].GetDescription()}");
            }

            string input = Console.ReadLine();

            if (input != null)
            {
                input = input.Trim();
            }

            bool isValidNumber = int.TryParse(input, out int index);

            if (isValidNumber && index >= 1 && index <= items.Count)
            {
                items.RemoveAt(index - 1);
                Console.WriteLine("Напитката е премахната от поръчката.");
            }
            else
            {
                Console.WriteLine("Невалиден избор. Моля, въведете правилен номер.");
            }
        }

        // Метод за финализиране на поръчката: приготвяне, плащане и изчистване на списъка
        private static void FinalizeOrder(List<IOrder> items)
        {
            if (items.Count == 0)
            {
                Console.WriteLine("Няма поръчани напитки за плащане.");
                return;
            }

            Console.WriteLine("Приготвяне на напитките...");

            foreach (IOrder item in items)
            {
                item.Prepare();
                System.Threading.Thread.Sleep(300); // пауза за по-реалистично усещане
            }

            double total = 0;

            foreach (IOrder item in items)
            {
                total += item.GetCost();
            }

            Console.WriteLine($"Обща сума за плащане: {total:F2} лв.");
            Console.WriteLine("Плащането е успешно. Благодарим Ви за поръчката!");

            // Изчистване на поръчката след плащане
            items.Clear();
        }
    }
}