using System;
using P03_SalesDatabase.Data;
using P03_SalesDatabase.Data.Models;
using System.Linq; 
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace P03_SalesDatabase
{
    public class Program
    {
        private static Random _random = new Random();
        
        static void Main()
        {
            using (var db = new SalesContext())
            {
                db.Database.EnsureDeleted(); 
                
                db.Database.Migrate(); 
        
                Console.WriteLine("Database migrated/created successfully.");
        
                Seed(db);

                Console.WriteLine("Done seeding data.");
            }
            Console.ReadKey();
        }
        
        public static void Seed(SalesContext db) //бонусне завдання
        {
            if (db.Products.Any())
            {
                Console.WriteLine("Products already exist.");
                return;
            }

            Console.WriteLine("Seeding random data...");
            
            var products = GenerateProducts(10); 
            db.Products.AddRange(products);
            Console.WriteLine($"{products}");
            
            var customers = GenerateCustomers(6); 
            db.Customers.AddRange(customers);
            
            var stores = GenerateStores(5); 
            db.Stores.AddRange(stores);
            
            db.SaveChanges();
            
            var sales = GenerateSales(30, products, customers, stores);
            db.Sales.AddRange(sales);
            
            db.SaveChanges();
            
            Console.WriteLine("Random data added successfully!");
        }

        private static List<Product> GenerateProducts(int count)
        {
            string[] names = { "Laptop", "Mouse", "Keyboard", "Monitor", "HDD", "SSD", "GPU", "RAM", "Headset", "Webcam" };
            var products = new List<Product>();

            for (int i = 0; i < count; i++)
            {
                string name = names[_random.Next(names.Length)] + " " + _random.Next(100, 999);
                
                products.Add(new Product
                {
                    Name = name,
                    Quantity = _random.Next(1, 100),     
                    Price = (decimal)(_random.NextDouble() * 2000 + 10)
                });
            }
            return products;
        }

        private static List<Customer> GenerateCustomers(int count)
        {
            string[] firstNames = { "Ivan", "Petro", "Maria", "Oksana", "John", "Alex", "Kate", "Dmytro" };
            string[] lastNames = { "Ivanenko", "Petrenko", "Smith", "Bond", "Koval", "Melnyk" };
            var customers = new List<Customer>();

            for (int i = 0; i < count; i++)
            {
                string first = firstNames[_random.Next(firstNames.Length)];
                string last = lastNames[_random.Next(lastNames.Length)];

                customers.Add(new Customer
                {
                    Name = $"{first} {last}",
                    Email = $"{first.ToLower()}.{last.ToLower()}@test.com",
                    CreditCardNumber = GenerateRandomCreditCard()
                });
            }
            return customers;
        }

        private static string GenerateRandomCreditCard()
        {
            var parts = new string[4];
            for (int i = 0; i < 4; i++)
            {
                parts[i] = _random.Next(1000, 9999).ToString();
            }
            return string.Join("-", parts);
        }

        private static List<Store> GenerateStores(int count)
        {
            string[] cities = { "Lviv", "Kyiv", "Odesa", "Kharkiv", "Dnipro", "Online" };
            var stores = new List<Store>();

            for (int i = 0; i < count; i++)
            {
                stores.Add(new Store
                {
                    Name = "SuperTech " + cities[_random.Next(cities.Length)]
                });
            }
            return stores;
        }

        private static List<Sale> GenerateSales(int count, List<Product> products, List<Customer> customers, List<Store> stores)
        {
            var sales = new List<Sale>();

            for (int i = 0; i < count; i++)
            {
                sales.Add(new Sale
                {
                    Product = products[_random.Next(products.Count)],
                    Customer = customers[_random.Next(customers.Count)],
                    Store = stores[_random.Next(stores.Count)],
                    
                    Date = DateTime.Now.AddDays(-_random.Next(0, 365)) 
                });
            }
            return sales;
        }
    }
}