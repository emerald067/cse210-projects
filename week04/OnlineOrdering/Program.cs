using System;
using OnlineOrdering;

class Program
{
    static void Main(string[] args)
    {
        // Customer lives in USA
        var address1 = new Address("123 Maple Street", "Springfield", "IL", "USA");
        var customer1 = new Customer("John Doe", address1);

        // Customer lives outside USA
        var address2 = new Address("47 King's Road", "London", "Greater London", "United Kingdom");
        var customer2 = new Customer("Jane Smith", address2);

        // Create product for order 1 (note decimal 'm' suffix)
        var product1 = new Product("Laptop", "SKU001", 999.99m, 1);
        var product2 = new Product("Mouse", "SKU002", 29.99m, 2);

        // Create products for order 2
        var product3 = new Product("Keyboard", "SKU003", 79.99m, 1);
        var product4 = new Product("Monitor", "SKU004", 199.99m, 2);
        var product5 = new Product("USB Cable", "SKU005", 9.99m, 3);

        // Order 1 - Customer in USA
        var order1 = new Order(customer1);
        order1.AddProduct(product1);
        order1.AddProduct(product2);

        // Order 2 - Customer outside USA
        var order2 = new Order(customer2);
        order2.AddProduct(product3);
        order2.AddProduct(product4);
        order2.AddProduct(product5);

        // Display results for order1
        Console.WriteLine("=== ORDER 1 ===");
        order1.DisplayPackingLabel();
        order1.DisplayShippingLabel();
        Console.WriteLine($"Shipping Cost: {order1.GetShippingCost():C}");
        Console.WriteLine($"Total Price (including shipping): {order1.CalculateTotal():C}");

        Console.WriteLine("\n-----------------------------\n");

        // Display results for order2
        Console.WriteLine("=== ORDER 2 ===");
        order2.DisplayPackingLabel();
        order2.DisplayShippingLabel();
        Console.WriteLine($"Shipping Cost: {order2.GetShippingCost():C}");
        Console.WriteLine($"Total Price (including shipping): {order2.CalculateTotal():C}");
    }
}
