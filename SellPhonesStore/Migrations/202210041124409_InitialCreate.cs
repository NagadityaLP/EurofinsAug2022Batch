namespace SellPhonesStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CustomerOrders",
                c => new
                    {
                        OrderId = c.Long(nullable: false, identity: true),
                        OrderDate = c.DateTime(nullable: false),
                        OrderTotal = c.Single(nullable: false),
                        customer_CustomerId = c.Int(),
                    })
                .PrimaryKey(t => t.OrderId)
                .ForeignKey("dbo.Customers", t => t.customer_CustomerId)
                .Index(t => t.customer_CustomerId);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        CustomerName = c.String(nullable: false, maxLength: 100),
                        EmailId = c.String(nullable: false),
                        City = c.String(),
                        StreetName = c.String(),
                        PinCode = c.String(),
                        MobileNo = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.CustomerId);
            
            CreateTable(
                "dbo.OrdereredPhones",
                c => new
                    {
                        OrdereredPhoneId = c.Long(nullable: false, identity: true),
                        Quantity = c.Single(nullable: false),
                        OrderedPhone_PhoneId = c.Long(),
                        CustomerOrder_OrderId = c.Long(),
                    })
                .PrimaryKey(t => t.OrdereredPhoneId)
                .ForeignKey("dbo.Phones", t => t.OrderedPhone_PhoneId)
                .ForeignKey("dbo.CustomerOrders", t => t.CustomerOrder_OrderId)
                .Index(t => t.OrderedPhone_PhoneId)
                .Index(t => t.CustomerOrder_OrderId);
            
            CreateTable(
                "dbo.Phones",
                c => new
                    {
                        PhoneId = c.Long(nullable: false, identity: true),
                        PhoneDesciption = c.String(nullable: false, maxLength: 500),
                        Price = c.Single(nullable: false),
                        ManufacturingDate = c.DateTime(nullable: false),
                        BrandName = c.String(),
                        InStock = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PhoneId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrdereredPhones", "CustomerOrder_OrderId", "dbo.CustomerOrders");
            DropForeignKey("dbo.OrdereredPhones", "OrderedPhone_PhoneId", "dbo.Phones");
            DropForeignKey("dbo.CustomerOrders", "customer_CustomerId", "dbo.Customers");
            DropIndex("dbo.OrdereredPhones", new[] { "CustomerOrder_OrderId" });
            DropIndex("dbo.OrdereredPhones", new[] { "OrderedPhone_PhoneId" });
            DropIndex("dbo.CustomerOrders", new[] { "customer_CustomerId" });
            DropTable("dbo.Phones");
            DropTable("dbo.OrdereredPhones");
            DropTable("dbo.Customers");
            DropTable("dbo.CustomerOrders");
        }
    }
}
