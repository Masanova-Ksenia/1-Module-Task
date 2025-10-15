using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_6
{
    public interface IPaymentStrategy
    {
        void Pay(decimal amount);
    }
    public class CreditCardPayment : IPaymentStrategy
    {
        private string _cardNumber;

        public CreditCardPayment(string cardNumber)
        {
            _cardNumber = cardNumber;
        }

        public void Pay(decimal amount)
        {
            Console.WriteLine($"Оплата {amount} произведена с банковской карты №{_cardNumber}");
        }
    }
    public class PayPalPayment : IPaymentStrategy
    {
        private string _email;

        public PayPalPayment(string email)
        {
            _email = email;
        }

        public void Pay(decimal amount)
        {
            Console.WriteLine($"Оплата {amount} произведена через PayPal аккаунт: {_email}");
        }
    }
    public class CryptoPayment : IPaymentStrategy
    {
        private string _walletAddress;

        public CryptoPayment(string walletAddress)
        {
            _walletAddress = walletAddress;
        }

        public void Pay(decimal amount)
        {
            Console.WriteLine($"Оплата {amount} произведена криптовалютой с кошелька: {_walletAddress}");
        }
    }
}


