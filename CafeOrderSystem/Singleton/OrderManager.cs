using System;
using System.Collections.Generic;
using System.Linq;
using CafeOrderSystem.FactoryMethod;

namespace CafeOrderSystem.Singleton
{
    public class OrderManager
    {
        private static readonly Lazy<OrderManager> _instance = 
            new Lazy<OrderManager>(() => new OrderManager());

        private readonly List<OrderItem> _currentOrder;
        private readonly List<Order> _orderHistory;
        private int _nextOrderId = 1;

        private OrderManager()
        {
            _currentOrder = new List<OrderItem>();
            _orderHistory = new List<Order>();
        }

        public static OrderManager Instance => _instance.Value;

        public void AddDrink(IDrink drink)
        {
            if (drink == null)
                throw new ArgumentNullException(nameof(drink));

            var existingItem = _currentOrder.FirstOrDefault(x => x.Drink.Name == drink.Name);
            if (existingItem != null)
            {
                existingItem.Quantity++;
            }
            else
            {
                _currentOrder.Add(new OrderItem(drink));
            }
        }

        public void RemoveDrink(string drinkName)
        {
            var item = _currentOrder.FirstOrDefault(x => x.Drink.Name.Equals(drinkName, StringComparison.OrdinalIgnoreCase));
            if (item == null)
                throw new InvalidOperationException($"Напитка '{drinkName}' не е намерена в текущата поръчка.");

            if (item.Quantity > 1)
                item.Quantity--;
            else
                _currentOrder.Remove(item);
        }

        public decimal GetTotal() => _currentOrder.Sum(item => item.Drink.Price * item.Quantity);

        public IReadOnlyList<OrderItem> GetCurrentOrder() => _currentOrder.AsReadOnly();

        public void ClearCurrentOrder() => _currentOrder.Clear();

        public Order FinalizeOrder(string paymentMethod)
        {
            if (_currentOrder.Count == 0)
                throw new InvalidOperationException("Не можете да финализирате празна поръчка.");

            var order = new Order(_nextOrderId++, 
                                new List<OrderItem>(_currentOrder), 
                                GetTotal(),
                                paymentMethod,
                                DateTime.Now);

            _orderHistory.Add(order);
            _currentOrder.Clear();
            return order;
        }

        public IReadOnlyList<Order> GetOrderHistory() => _orderHistory.AsReadOnly();
    }

    public class OrderItem
    {
        public IDrink Drink { get; }
        public int Quantity { get; set; }

        public OrderItem(IDrink drink)
        {
            Drink = drink ?? throw new ArgumentNullException(nameof(drink));
            Quantity = 1;
        }

        public decimal GetSubtotal() => Drink.Price * Quantity;
    }

    public class Order
    {
        public int OrderId { get; }
        public IReadOnlyList<OrderItem> Items { get; }
        public decimal TotalAmount { get; }
        public string PaymentMethod { get; }
        public DateTime OrderDate { get; }

        public Order(int orderId, List<OrderItem> items, decimal totalAmount, string paymentMethod, DateTime orderDate)
        {
            OrderId = orderId;
            Items = items;
            TotalAmount = totalAmount;
            PaymentMethod = paymentMethod;
            OrderDate = orderDate;
        }
    }
}
