using System;

namespace ЛабораторнаяРабота_2
{
    //DRY
    public class OrderService
    {
        private void PrintOrder(string action, string productName, int quantity, double price)
        {
            double totalPrice = quantity * price;
            Console.WriteLine($"Order for {productName} {action}. Total: {totalPrice}");
        }
        public void CreateOrder(string productName, int quantity, double price)
        {
            PrintOrder("created", productName, quantity, price);
        }
        public void UpdateOrder(string productName, int quantity, double price)
        {
            PrintOrder("updated", productName, quantity, price);
        }
    }
    public abstract class Vehicle
    {
        public void Start() => Console.WriteLine($"{GetType().Name} is starting");
        public void Stop() => Console.WriteLine($"{GetType().Name} is stopping");
    }
    public class Car : Vehicle { }
    public class Truck : Vehicle { }
    //KISS
    public class Calculator
    {
        public int Add(int a, int b) => a + b;
    }
    public class SimpleAction
    {
        public void DoSomething() => Console.WriteLine("Doing something simple...");
    }
    //YAGNI
    public class Circle
    {
        private double _radius;
        public Circle(double radius)
        {
            _radius = radius;
        }
        public double CalculateArea()
        {
            return Math.PI * _radius * _radius;
        }
    }
    public class MathOperations
    {
        public int Add(int a, int b) => a + b;
    }
    class Program
    {
        static void Main()
        {
            Console.WriteLine("DRY");
            var orderService = new OrderService();
            orderService.CreateOrder("Laptop", 2, 1000);
            orderService.UpdateOrder("Laptop", 3, 950);

            var car = new Car();
            car.Start();
            car.Stop();

            var truck = new Truck();
            truck.Start();
            truck.Stop();

            Console.WriteLine("\nKISS");
            var calc = new Calculator();
            Console.WriteLine($"2 + 3 = {calc.Add(2, 3)}");

            var action = new SimpleAction();
            action.DoSomething();

            Console.WriteLine("\nYAGNI");
            var circle = new Circle(5);
            Console.WriteLine($"Circle area: {circle.CalculateArea()}");

            var math = new MathOperations();
            Console.WriteLine($"4 + 6 = {math.Add(4, 6)}");
        }
    }
}