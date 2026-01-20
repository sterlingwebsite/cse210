using System;

class Program
{
    static void Main(string[] args)
    {
        // Console.WriteLine("Hello World! This is the OnlineOrdering Project.");

        // Order 1
        Address address1 = new Address(
            "123 Main Street",
            "Salt Lake City",
            "UT",
            "USA"
        );

        Customer customer1 = new Customer("Sterling Steele", address1);

        List<Product> products1 = new List<Product>()
        {
            new Product("Brake Pads", "BP001", 45.99, 2),
            new Product("Oil Filter", "OF123", 12.49, 1),
            new Product("AirFilter", "AF789", 18.99, 1)
        };

        Order order1 = new Order(products1, customer1);

        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order1.GetTotalCost():0.00}");
        Console.WriteLine("________________________________________");

        // Order 2
        Address address2 = new Address(
            "55 King Street",
            "Toronto",
            "ON",
            "Canada"
        );

        Customer customer2 = new Customer("Alex Johnson", address2);

        List<Product> products2 = new List<Product>()
        {
            new Product("Spark Plugs", "SP555", 9.99, 4),
            new Product("Wiper Blades", "WB222", 14.99, 2),
        };

        Order order2 = new Order(products2, customer2);

        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order2.GetTotalCost():0.00}");
    }
}