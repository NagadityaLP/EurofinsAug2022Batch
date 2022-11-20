using System;
using System.Collections.Generic;
using System.Linq;

namespace FrequencyCount
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> frequency = new Dictionary<string, int>();
            for(int i = 0; i < args.Length; i++)
            {
                if(frequency.ContainsKey(args[i]))
                    frequency[args[i]] += 1;
                else
                    frequency[args[i]] = 1;
            }
            foreach (string key in frequency.Keys)
                Console.Write($"{key} = {frequency[key]}\n");

            Console.WriteLine("\n*************************************************************\n");

            var x = from a in args
                    orderby a.Length ascending
                    select a;
            foreach (var item in x)
                Console.WriteLine(item);

            Console.WriteLine("\n*************************************************************\n");

            Entity[] entities = new Entity[4];
            entities[0] = new Entity(200,"Dell","15 inch Monitor",3400.44);
            entities[1] = new Entity(120,"Dell","Laptop",45000.00);
            entities[2] = new Entity(150,"Microsoft","Windows 7",7000.50);
            entities[3] = new Entity(100,"Logitech","Optical Mouse",540.00);

            Console.WriteLine("Sorting based on Product ID : ");
            var entity = from a in entities
                         orderby a.ProductID ascending
                         select a;
            foreach (var item in entity)
                Console.WriteLine($"{item.ProductID}    {item.BrandName}    {item.Description}  {item.Price}");

            Console.WriteLine("\nSorting based on Brand name or price? 'BrandName' or 'Price':");
            string choice = Console.ReadLine();
            if(choice == "BrandName")
            {
                var entity1 = from a in entities
                             orderby a.BrandName, a.Description ascending
                             select a;
                foreach (var item in entity1)
                    Console.WriteLine($"{item.ProductID}    {item.BrandName}    {item.Description}  {item.Price}");
            }
            else if(choice == "Price")
            {
                var entity2 = from a in entities
                             orderby a.Price, a.ProductID ascending
                             select a;
                foreach (var item in entity2)
                    Console.WriteLine($"{item.ProductID}    {item.BrandName}    {item.Description}  {item.Price}");
            }
        }
    }
    class Entity
    {
        public int ProductID;
        public string BrandName;
        public string Description;
        public double Price;
        public Entity(int productID, string brandName, string description, double price)
        {
            ProductID = productID;
            BrandName = brandName;
            Description = description;
            Price = price;
        }
    }
}
