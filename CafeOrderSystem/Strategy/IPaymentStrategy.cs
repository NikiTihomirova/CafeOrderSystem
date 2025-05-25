using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeOrderSystem.Strategy
{
    public interface IPaymentStrategy
    {
        PaymentResult ProcessPayment(decimal amount);
    }

    public class PaymentResult
    {
        public bool Success { get; }
        public string Message { get; }
        public string TransactionId { get; }
        public DateTime Timestamp { get; }

        public PaymentResult(bool success, string message, string transactionId = null)
        {
            Success = success;
            Message = message;
            TransactionId = transactionId;
            Timestamp = DateTime.Now;
        }
    }
}
