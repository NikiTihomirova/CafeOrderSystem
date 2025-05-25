using System;
using CafeOrderSystem.FactoryMethod;
using CafeOrderSystem.Singleton;
using CafeOrderSystem.Strategy;

namespace CafeOrderSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                RunCafeOrderSystem();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nВъзникна грешка: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("\nНатиснете произволен клавиш за изход...");
                Console.ReadKey();
            }
        }

        static void RunCafeOrderSystem()
        {
            var factory = new DrinkFactory();
            var orderManager = OrderManager.Instance;

            Console.WriteLine("=== Добре дошли в нашето кафене! ===");
            
            while (true)
            {
                ShowMainMenu();
                var choice = Console.ReadLine()?.Trim().ToLower();

                switch (choice)
                {
                    case "1":
                        ProcessOrder(factory, orderManager);
                        break;
                    case "2":
                        ShowCurrentOrder(orderManager);
                        break;
                    case "3":
                        RemoveItemFromOrder(orderManager);
                        break;
                    case "4":
                        if (ProcessPayment(orderManager))
                            return;
                        break;
                    case "изход":
                        return;
                    default:
                        Console.WriteLine("Невалиден избор. Моля, опитайте отново.");
                        break;
                }
            }
        }

        static void ShowMainMenu()
        {
            Console.WriteLine("\nМеню:");
            Console.WriteLine("1. Добави напитка");
            Console.WriteLine("2. Преглед на поръчката");
            Console.WriteLine("3. Премахни напитка");
            Console.WriteLine("4. Плащане");
            Console.WriteLine("'изход' за край");
            Console.Write("\nИзбор: ");
        }

        static void ProcessOrder(DrinkFactory factory, OrderManager orderManager)
        {
            var availableDrinks = DrinkFactory.GetAvailableDrinks();
            Console.WriteLine($"\nНалични напитки: {string.Join(", ", availableDrinks)}");
            Console.Write("Изберете напитка: ");

            var input = Console.ReadLine()?.Trim().ToLower();
            if (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("Невалиден избор.");
                return;
            }

            try
            {
                var drink = factory.CreateDrink(input);
                orderManager.AddDrink(drink);
                Console.WriteLine($"Добавено: {drink.Name} – {drink.Price:F2} лв.");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void ShowCurrentOrder(OrderManager orderManager)
        {
            var currentOrder = orderManager.GetCurrentOrder();
            if (currentOrder.Count == 0)
            {
                Console.WriteLine("\nПоръчката е празна.");
                return;
            }

            Console.WriteLine("\nТекуща поръчка:");
            foreach (var item in currentOrder)
            {
                Console.WriteLine($"{item.Drink.Name} x{item.Quantity} = {item.GetSubtotal():F2} лв.");
            }
            Console.WriteLine($"Обща сума: {orderManager.GetTotal():F2} лв.");
        }

        static void RemoveItemFromOrder(OrderManager orderManager)
        {
            var currentOrder = orderManager.GetCurrentOrder();
            if (currentOrder.Count == 0)
            {
                Console.WriteLine("\nПоръчката е празна.");
                return;
            }

            Console.WriteLine("\nИзберете напитка за премахване:");
            foreach (var item in currentOrder)
            {
                Console.WriteLine($"{item.Drink.Name} (количество: {item.Quantity})");
            }

            Console.Write("\nНапитка: ");
            var input = Console.ReadLine()?.Trim();
            
            try
            {
                orderManager.RemoveDrink(input);
                Console.WriteLine("Напитката е премахната успешно.");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static bool ProcessPayment(OrderManager orderManager)
        {
            if (orderManager.GetCurrentOrder().Count == 0)
            {
                Console.WriteLine("\nНяма какво да платите - поръчката е празна.");
                return false;
            }

            Console.WriteLine("\nИзберете начин на плащане:");
            Console.WriteLine("1. В брой");
            Console.WriteLine("2. С карта");
            Console.Write("Избор: ");

            var paymentChoice = Console.ReadLine()?.Trim();
            string paymentMethod = paymentChoice switch
            {
                "1" => "в брой",
                "2" => "с карта",
                _ => null
            };

            if (paymentMethod == null)
            {
                Console.WriteLine("Невалиден начин на плащане.");
                return false;
            }

            try
            {
                var paymentContext = new PaymentContext();
                paymentContext.SetStrategy(PaymentContext.CreatePaymentStrategy(paymentMethod));

                var total = orderManager.GetTotal();
                var paymentResult = paymentContext.ExecutePayment(total);

                if (paymentResult.Success)
                {
                    var order = orderManager.FinalizeOrder(paymentMethod);
                    Console.WriteLine($"\nПоръчка #{order.OrderId}");
                    Console.WriteLine($"Транзакция: {paymentResult.TransactionId}");
                    Console.WriteLine(paymentResult.Message);
                    Console.WriteLine("Благодарим ви! Приятен ден!");
                    return true;
                }
                else
                {
                    Console.WriteLine($"\nГрешка при плащането: {paymentResult.Message}");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nГрешка при обработката на плащането: {ex.Message}");
                return false;
            }
        }
    }
}
