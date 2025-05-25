using System;

namespace CafeOrderSystem.Strategy
{
    public class CardPayment : IPaymentStrategy
    {
        public PaymentResult ProcessPayment(decimal amount)
        {
            // In a real system, this would interface with a payment processor
            Console.WriteLine($"Обработка на картово плащане: {amount:F2} лв.");
            return new PaymentResult(
                success: true,
                message: $"Картовото плащане на сума {amount:F2} лв. е успешно.",
                transactionId: $"CARD_{DateTime.Now:yyyyMMddHHmmss}"
            );
        }
    }
}
