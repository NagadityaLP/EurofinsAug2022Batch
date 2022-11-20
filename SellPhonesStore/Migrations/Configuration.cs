namespace SellPhonesStore.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SellPhonesStore.DataAccess.SellPhonesStoreDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "SellPhonesStore.DataAccess.SellPhonesStoreDbContext";
        }

        protected override void Seed(SellPhonesStore.DataAccess.SellPhonesStoreDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
