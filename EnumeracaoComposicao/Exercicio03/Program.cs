using System;
using System.Globalization;
using Exercicio03.Entities;
using Exercicio03.Entities.Enums;

namespace Exercicio03;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter client data:");
        Console.Write("Name: ");
        string nameClient = Console.ReadLine();

        Console.Write("Email: ");
        string emailClient = Console.ReadLine();

        Console.Write("Birth date (MM/dd/yyyy): ");
        DateTime birthDate = DateTime.Parse(Console.ReadLine());

        Console.WriteLine("Enter order data:");
        Console.Write("Status: ");
        OrderStatus status = Enum.Parse<OrderStatus>(Console.ReadLine());

        Client client = new Client(nameClient, emailClient, birthDate);
        Order order = new Order(DateTime.Now, status, client);

        Console.Write("How many items to this order? ");
        int n = int.Parse(Console.ReadLine());

        for (int i = 1; i <= n; i++)
        {
            Console.WriteLine($"Enter #{i} item data:");
            Console.Write("Product name: ");
            string productName = Console.ReadLine();

            Console.Write("Product price: $");
            double productPrice = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Product product = new Product(productName, productPrice);

            Console.Write("Quantity: ");
            int quantity = int.Parse(Console.ReadLine());

            OrderItem orderItem = new OrderItem(quantity, productPrice, product);

            order.AddItem(orderItem);
        }

        Console.WriteLine();

        Console.WriteLine("ORDER SUMMARY:");
        Console.WriteLine(order);
    }
}

