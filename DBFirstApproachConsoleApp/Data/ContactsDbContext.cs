using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace DBFirstApproachConsoleApp.Data
{
    public partial class ContactsDbContext : DbContext
    {
        public ContactsDbContext()
            : base("name=ContactsDbContext")
        {
        }

        public virtual DbSet<contact> contacts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<contact>()
                .Property(e => e.Name)
                .IsFixedLength();

            modelBuilder.Entity<contact>()
                .Property(e => e.Mobile)
                .IsFixedLength();

            modelBuilder.Entity<contact>()
                .Property(e => e.Email)
                .IsFixedLength();

            modelBuilder.Entity<contact>()
                .Property(e => e.Location)
                .IsFixedLength();
        }
    }
}
