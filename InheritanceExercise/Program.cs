using System;
using System.Diagnostics;

namespace InheritanceExercise
{
    internal class Invest
    {
        static void Main(string[] args)
        {
            Stock microsoft = new Stock("Microsoft", 8000, 1994, "MSFT", 200, 56);
            Building beachHouse = new Building("Beach House", 9000, 1964, 35000, "123 Seashore Ave, Malibu, CA");
            Art nighthawks = new Art("Nighthawks", 850, 1955, 7500, "Edward Hopper", 1942);

            Console.WriteLine("Amortized costs per year:");
            Console.WriteLine("Microsoft stock ${0}", microsoft.AmortizedCost(2002));
            Console.WriteLine("Beach house ${0}", beachHouse.AmortizedCost(2002));
            Console.WriteLine("Nighthawks ${0}\n", nighthawks.AmortizedCost(2002));

            Console.WriteLine("Valuations:");
            Console.WriteLine("Microsoft stock ${0}", microsoft.ComputeValue());
            Console.WriteLine("Beach House ${0}", beachHouse.ComputeValue());
            Console.WriteLine("Nighthawks ${0}\n", nighthawks.ComputeValue());

            microsoft.Print();
            beachHouse.Print();
            nighthawks.Print();
        }
    }   
    class Asset
    {
        private string name;
        private double cost;
        private int yearPurchased;

        public Asset(string name, double cost, int yearPurchased)
        {
            this.name = name;
            this.cost = cost;
            this.yearPurchased = yearPurchased;
        }
        public double AmortizedCost(int currentYear)
        {
            return cost / (currentYear - yearPurchased);
        }
        public double ComputeValue()
        {
            return cost;
        }
        public void Print()
        {
            Console.WriteLine("\nAsset class called");
        }
    }
    class Stock : Asset
    {
        private string symbol;
        private int shares;
        private double price;

        public Stock(string name, double cost, int yearPurchased,string symbol, int shares, double price)
            :base(name, cost, yearPurchased)
        {
            this.symbol = symbol;
            this.shares = shares;
            this.price = price;

            Console.WriteLine($"{name} stock has been purchased in {yearPurchased} which costs Rs. {cost}." +
                $"It's symbol is {symbol}. Number of shares bought is {shares} and now the price is Rs. {price}.\n");
        }
        public new double ComputeValue()
        {
            return shares * price;
        }
        public new void Print()
        {
            base.Print();
            Console.WriteLine("Stock class called");
        }
    }
    class Property : Asset
    {
        private double assessment;
        public Property(string name, double cost, int yearPurchased, double assessment)
            :base(name, cost, yearPurchased)
        {
            this.assessment = assessment;
        }
        public new double ComputeValue()
        {
            return assessment;
        }
        public new void Print()
        {
            base.Print();
            Console.WriteLine("Property class called");
        }
    }
    class Building : Property
    {
        private string address;
        public Building(string name, double cost, int yearPurchased, double assessment,string address)
            :base(name, cost, yearPurchased, assessment)
        {
            this.address = address;
            Console.WriteLine($"Asset named {name} has been bought for Rs. {cost} in the year {yearPurchased}." +
                $"Assessed value is {assessment} and its address is {address}\n");
        }
        public new void Print()
        {
            base.Print();
            Console.WriteLine("Building class called");
        }
    }
    class Art : Property
    {
        private string artist;
        private int yearCreated;
        public Art(string name, double cost, int yearPurchased, double assessment, string artist, int yearCreated)
            : base(name, cost, yearPurchased, assessment)
        {
            this.artist = artist;
            this.yearCreated = yearCreated;

            Console.WriteLine($"Asset named {name} has been bought for Rs. {cost} in the year {yearPurchased}." +
                $"Assessed value is {assessment}. This art is created by {artist} in the year {yearCreated}\n");
        }
        public new void Print()
        {
            base.Print();
            Console.WriteLine("Art class called");
        }
    }
}
