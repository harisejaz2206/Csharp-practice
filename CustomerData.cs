using System;
using System.Collections.Generic;

public class Order
{
    public int Id { get; set; }
    public string CustomerId { get; set; }
    public DateTime OrderDate { get; set; }
    public decimal Total { get; set; }
    public List<OrderItem> Items { get; set; }
    public OrderStatus Status { get; set; }
}

public class OrderItem
{
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal Discount { get; set; }
}

public class Customer
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Region { get; set; }
    public CustomerType Type { get; set; }
    public List<Order> Orders { get; set; }
}

// Enums for OrderStatus and CustomerType
public enum OrderStatus
{
    Pending,
    Completed,
    Canceled
}

public enum CustomerType
{
    Regular,
    Premium,
    VIP
}

public class CustomerData
{
    public static void Solve()
    {
        // Sample data for customers
        List<Customer> customers = new List<Customer>
        {
            new Customer
            {
                Id = "C1",
                Name = "Alice",
                Region = "North",
                Orders = new List<Order>
                {
                    new Order { Id = 1, Total = 200, OrderDate = DateTime.Now, Status = OrderStatus.Completed, Items = new List<OrderItem>() },
                    new Order { Id = 2, Total = 150, OrderDate = DateTime.Now, Status = OrderStatus.Completed, Items = new List<OrderItem>() }
                }
            },
            new Customer
            {
                Id = "C2",
                Name = "Bob",
                Region = "North",
                Orders = new List<Order>
                {
                    new Order { Id = 3, Total = 300, OrderDate = DateTime.Now, Status = OrderStatus.Completed, Items = new List<OrderItem>() },
                    new Order { Id = 4, Total = 100, OrderDate = DateTime.Now, Status = OrderStatus.Completed, Items = new List<OrderItem>() }
                }
            },
            new Customer
            {
                Id = "C3",
                Name = "Charlie",
                Region = "North",
                Orders = new List<Order>
                {
                    new Order { Id = 5, Total = 50, OrderDate = DateTime.Now, Status = OrderStatus.Completed, Items = new List<OrderItem>() },
                    new Order { Id = 6, Total = 75, OrderDate = DateTime.Now, Status = OrderStatus.Completed, Items = new List<OrderItem>() }
                }
            },
            new Customer
            {
                Id = "C4",
                Name = "Diana",
                Region = "South",
                Orders = new List<Order>
                {
                    new Order { Id = 7, Total = 400, OrderDate = DateTime.Now, Status = OrderStatus.Completed, Items = new List<OrderItem>() }
                }
            },
            new Customer
            {
                Id = "C5",
                Name = "Eve",
                Region = "South",
                Orders = new List<Order>
                {
                    new Order { Id = 8, Total = 350, OrderDate = DateTime.Now, Status = OrderStatus.Completed, Items = new List<OrderItem>() },
                    new Order { Id = 9, Total = 150, OrderDate = DateTime.Now, Status = OrderStatus.Completed, Items = new List<OrderItem>() }
                }
            },
            new Customer
            {
                Id = "C6",
                Name = "Frank",
                Region = "South",
                Orders = new List<Order>
                {
                    new Order { Id = 10, Total = 200, OrderDate = DateTime.Now, Status = OrderStatus.Completed, Items = new List<OrderItem>() },
                    new Order { Id = 11, Total = 100, OrderDate = DateTime.Now, Status = OrderStatus.Completed, Items = new List<OrderItem>() }
                }
            }
        };

        // You can add logic here to work with the customers data
        // For example, print customer names
        foreach (var customer in customers)
        {
            Console.WriteLine($"Customer: {customer.Name}, Region: {customer.Region}, Total Orders: {customer.Orders.Count}");
        }
    }
}

