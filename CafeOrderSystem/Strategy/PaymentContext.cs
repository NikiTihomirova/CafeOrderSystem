using System;

namespace CafeOrderSystem.Strategy
{
    public class PaymentContext
    {
        private IPaymentStrategy _strategy;

        public void SetStrategy(IPaymentStrategy strategy)
        {
            _strategy = strategy ?? throw new ArgumentNullException(nameof(strategy));
        }

        public PaymentResult ExecutePayment(decimal amount)
        {
            if (_strategy == null)
                throw new InvalidOperationException("Моля, изберете метод на плащане преди да продължите.");

            if (amount <= 0)
                throw new ArgumentException("Сумата за плащане трябва да бъде положително число.", nameof(amount));

            return _strategy.ProcessPayment(amount);
        }

        public static IPaymentStrategy CreatePaymentStrategy(string method)
        {
            return method?.ToLower() switch
            {
                "в брой" => new CashPayment(),
                "с карта" => new CardPayment(),
                _ => throw new ArgumentException($"Невалиден метод на плащане: {method}")
            };
        }
    }
}
