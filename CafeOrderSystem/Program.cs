using System;
using System.Collections.Generic;
using CafeteriaOrderSystem.FactoryMethod;
using CafeteriaOrderSystem.Decorator;
using CafeOrderSystem.Decorator;

namespace CafeteriaOrderSystem
{
    class Program
    {
        static void Main() => RunSystem();

        static void RunSystem()
        {
            List<IOrder> currentOrderItems = new();

            while (true)
            {
                Console.WriteLine("\nМеню:\n1. Поръчай напитка\n2. Виж поръчката\n3. Премахни напитка\n4. Плащане\n0. Изход");
                Console.Write("Избор: ");
                string choice = Console.ReadLine()?.Trim();

                switch (choice)
                {
                    case "1":
                        var orderItem = ChooseDrink();
                        if (orderItem != null)
                        {
                            orderItem = ChooseExtras(orderItem);
                            currentOrderItems.Add(orderItem);
                            Console.WriteLine("Напитката е добавена към поръчката.");
                        }
                        break;
                    case "2": ShowOrder(currentOrderItems); break;
                    case "3": RemoveItem(currentOrderItems); break;
                    case "4": FinalizeOrder(currentOrderItems); break;
                    case "0": Console.WriteLine("Излизане от системата. Приятен ден!"); return;
                    default: Console.WriteLine("Невалидна команда."); break;
                }
            }
        }

        static IOrder ChooseDrink()
        {
            Console.WriteLine("\nИзберете напитка:\n1. Кафе\n2. Чай\n3. Сок\n4. Лимонада");
            Console.Write("Ваш избор: ");
            string input = Console.ReadLine()?.Trim();
            return input switch
            {
                "1" => OrderFactory.CreateOrder("coffee"),
                "2" => OrderFactory.CreateOrder("tea"),
                "3" => OrderFactory.CreateOrder("juice"),
                "4" => OrderFactory.CreateOrder("lemonade"),
                _ => null
            };
        }

        static IOrder ChooseExtras(IOrder order)
        {
            while (true)
            {
                Console.WriteLine("\nДобавки:\n1. Захар (+0.20 лв.)\n2. Мента (+0.30 лв.)\n3. Мед (+0.50 лв.)\n4. Лед (+0.20 лв.)\n0. Готово");
                Console.Write("Избор: ");
                string choice = Console.ReadLine()?.Trim();

                order = choice switch
                {
                    "1" => new SugarDecorator(order),
                    "2" => new MintDecorator(order),
                    "3" => new HoneyDecorator(order),
                    "4" => new IceDecorator(order),
                    "0" => order,
                    _ => order
                };

                if (choice == "0") return order;
                Console.WriteLine("Добавката е добавена.");
            }
        }

        static void ShowOrder(List<IOrder> items)
        {
            if (items.Count == 0) { Console.WriteLine("Поръчката е празна."); return; }
            Console.WriteLine("\nТекуща поръчка:");
            double total = 0;
            for (int i = 0; i < items.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {items[i].GetDescription()} - {items[i].GetCost():0.00} лв.");
                total += items[i].GetCost();
            }
            Console.WriteLine($"Обща сума: {total:0.00} лв.");
        }

        static void RemoveItem(List<IOrder> items)
        {
            if (items.Count == 0) { Console.WriteLine("Няма какво да премахнете."); return; }
            Console.WriteLine("Изберете номер на напитка за премахване:");
            for (int i = 0; i < items.Count; i++)
                Console.WriteLine($"{i + 1}. {items[i].GetDescription()}");

            if (int.TryParse(Console.ReadLine(), out int index) && index >= 1 && index <= items.Count)
            {
                items.RemoveAt(index - 1);
                Console.WriteLine("Напитката е премахната.");
            }
            else Console.WriteLine("Невалиден избор.");
        }

        static void FinalizeOrder(List<IOrder> items)
        {
            if (items.Count == 0) { Console.WriteLine("Няма какво да се плати."); return; }
            Console.WriteLine("Приготвяне на напитките...");
            foreach (var item in items)
            {
                item.Prepare();
                System.Threading.Thread.Sleep(300);
            }
            double total = 0;
            foreach (var item in items) total += item.GetCost();
            Console.WriteLine($"Обща сума за плащане: {total:0.00} лв.\nПлатено успешно. Благодарим Ви!");
            items.Clear();
        }
    }
}