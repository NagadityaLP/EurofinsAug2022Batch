using System;
using System.Collections.Generic;

namespace MembershipApp_04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Company company = new Company();
            company.setName("Eurofins IT Solutions India Pvt Ltd.");
            
            Customer customer = new Customer();
            customer.setCustId("E57B");
            customer.setName("Dheeraj");
            customer.setEmail("dheeraj6785@eurofins.com");

            Customer customer1 = new Customer();
            customer1.setCustId("E83N");
            customer1.setName("Sanju");
            customer1.setEmail("sanjay5656@eurofins.com");

            company.addCustomer(customer);
            company.addCustomer(customer1);

            Console.WriteLine($"Company with name {company.getName()} has been started and its customers " +
                $"are : {customer.getName()} and {customer1.getName()}\n");

            RegCustomer regCustomer = new RegCustomer();
            regCustomer.setCustId("EITS3456");
            regCustomer.setName("Geeta");
            regCustomer.setEmail("geeta1967@eurofins.com");
            regCustomer.setDtReg("23-09-2020");

            /*Membership membership = new Membership();
            membership.setTypeOfMembership("Life-long");
            membership.setDiscount(1500.56);
            membership.setFees(4789.99);*/
            
            MembershipFactory mf = MembershipFactory.getInstance();
            Membership membership = mf.createMembership("Life-long", 4789.66, 1500.56);
            Membership membership1 = mf.createMembership("Life-long", 7489.66, 1800.56);
            Membership membership2 = mf.createMembership("Life-long", 8479.66, 2200.56);
            Membership membership3 = mf.create("Yearly");
            regCustomer.setMembership(membership);

            mf.MembershipList.Add(membership);
            mf.MembershipList.Add(membership1);
            mf.MembershipList.Add(membership2);
            mf.MembershipList.Add(membership3);

            Console.WriteLine($"{regCustomer.getName()} is a registered customer. His/her customer ID is {regCustomer.getCustId()}" +
                $", email id is {regCustomer.getEmail()} and date of registration is {regCustomer.getDtReg()}" +
                $"and his membership type is {regCustomer.getMembership().getTypeOfMembership()} and can get the dicount" +
                $" of Rs. {regCustomer.getMembership().getDiscount()} and the membership fees paid is Rs. {regCustomer.getMembership().getFees()}\n");


            Console.WriteLine("Memberships created by Membership Factory are : \n\n");
            for(int i = 0; i < mf.MembershipList.Count; i++)
            {
                Console.WriteLine($"Type of Membership : {mf.MembershipList[i].getTypeOfMembership()}");
                Console.WriteLine($"Discount given : {mf.MembershipList[i].getDiscount()}");
                Console.WriteLine($"Membership Fees : {mf.MembershipList[i].getFees()}\n");    
            }
        }
    }
    class Company
    {
        private string name;
        private List<Customer> customers { get; set; } 
        public Company()
        {
            customers = new List<Customer>();
            Console.WriteLine("Company Instance created.\n");
        }
        public void setName(string name)
        {
            this.name = name;
        }
        public string getName()
        {
            return name;
        }
        public void addCustomer(Customer customer)
        {
            customers.Add(customer);
        }
        public List<Customer> getCustomers()
        {
            return customers;
        }
    }
    class Customer
    {
        private string custId;
        private string name;
        private string email;
        public Customer()
        {
            Console.WriteLine("Customer instance created\n");
        }
        public string getCustId()
        {
            return custId;
        }
        public void setCustId(string custId)
        {
            this.custId = custId;
        }
        public string getName()
        {
            return name;
        }
        public void setName(string name)
        {
            this.name = name;
        }
        public string getEmail()
        {
            return email;
        }
        public void setEmail(string email)
        {
            this.email = email;
        }
    }
    class RegCustomer : Customer
    {
        private string dtReg;
        private Membership membership;
        public RegCustomer() 
        {
            Console.WriteLine("Registered Customer instance created.\n");
        }
        public string getDtReg()
        {
            return dtReg;
        }
        public void setDtReg(string dtReg)
        {
            this.dtReg = dtReg;
        }
        public void setMembership(Membership membership)
        {
            this.membership = membership;
        }
        public Membership getMembership()
        {
            return membership;
        }
        public string getTypeOfMembership()
        {
            return membership.getTypeOfMembership();
        }
        public double getDiscount()
        {
            return membership.getDiscount();
        }
        public double getFees()
        {
            return membership.getFees();
        }
    }
    class Membership
    {
        private string typeOfMembership;
        private double discount;
        private double fees;

        internal Membership()
        {
            Console.WriteLine("Membership instance created.\n");
        }
        public string getTypeOfMembership()
        {
            return typeOfMembership;    
        }
        public void setTypeOfMembership(string typeOfMembership)
        {
            this.typeOfMembership = typeOfMembership;
        }
        public double getDiscount()
        {
            return discount;
        }
        public void setDiscount(double discount)
        {
            this.discount = discount;
        }
        public double getFees()
        {
            return fees;
        }
        public void setFees(double fees)
        {
            this.fees = fees;
        }
    }
    class MembershipFactory
    {
        private Dictionary<string, Membership> pool;
        private static MembershipFactory mf;

        public List<Membership> MembershipList { get; set; } = new List<Membership> ();
        private MembershipFactory()
        {
            pool = new Dictionary<string, Membership>();

        }
        public Membership createMembership(string typeOfMembership, double fees, double discount)
        {
            Membership membership = new Membership();
            membership.setTypeOfMembership(typeOfMembership);
            membership.setDiscount(discount);
            membership.setFees(fees);
            return membership;
        }
        public Membership create(string typeOfMembership)
        {
            Membership membership = new Membership();
            membership.setTypeOfMembership(typeOfMembership);
            return membership;

        }
        public static MembershipFactory getInstance()
        {
            mf = new MembershipFactory();
            return mf;
        }
    }
}
