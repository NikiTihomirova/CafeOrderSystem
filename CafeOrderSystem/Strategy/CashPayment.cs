using System;

namespace CafeOrderSystem.Strategy
{
    public class CashPayment : IPaymentStrategy
    {
        public PaymentResult ProcessPayment(decimal amount)
        {
            // In a real system, this would interface with a cash register or POS system
            Console.WriteLine($"Обработка на плащане в брой: {amount:F2} лв.");
            return new PaymentResult(
                success: true,
                message: $"Плащането в брой на сума {amount:F2} лв. е успешно.",
                transactionId: $"CASH_{DateTime.Now:yyyyMMddHHmmss}"
            );
        }
    }
}
