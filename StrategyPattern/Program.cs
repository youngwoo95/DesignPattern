namespace StrategyPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ShoppingCart cart = new ShoppingCart();

            cart.setPaymentStrategy(new CreditCardPayment("John Doe", "1234567890123456"));
            cart.checkout(100);

            cart.setPaymentStrategy(new PayPalPayment("johndoe@example.com"));

            cart.checkout(200);
        }
    }

    // * [1] 인터페이스
    interface PaymentStrategy
    {
        void pay(int amount);
    }

    // * [1] 인터페이스 구현
    class CreditCardPayment : PaymentStrategy
    {
        private string name;
        private string cardNumber;

        public CreditCardPayment(string name, string cardNumber)
        {
            this.name = name;
            this.cardNumber = cardNumber;
        }

        public void pay(int amount)
        {
            Console.WriteLine($"{amount} paid with credit card");
        }
    }

    // * [1] 인터페이스 구현
    class PayPalPayment : PaymentStrategy
    {
        private string email;
        
        public PayPalPayment(string email)
        {
            this.email = email;
        }

        public void pay(int amount)
        {
            Console.WriteLine($"{amount} paid using PayPal");
        }
    }

    // Context Class
    class ShoppingCart
    {
        // 이 자리에 해당 인터페이스를 적용한 두 클래스 중 하나가 들어갈 수 있다.
        private PaymentStrategy paymentStrategy;

        // 이 필드를 언제든 다른 전략으로 대체할 수 있도록 Setter 메서드도 있음.
        public void setPaymentStrategy(PaymentStrategy paymentStrategy)
        {
            this.paymentStrategy = paymentStrategy;
        }

        // checkout 메서드를 실행하면 현재 장착된 전략 객체의 pay 메서드가 실행된다.
        public void checkout(int amount)
        {
            paymentStrategy.pay(amount);
        }
    }




}
