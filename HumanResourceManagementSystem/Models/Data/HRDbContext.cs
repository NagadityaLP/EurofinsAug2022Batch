
using HumanResourceManagementSystem.Models.Entities;
using System.Data.Entity;
namespace HumanResourceManagementSystem.Models.Data
{
    public class HRDbContext : DbContext
    {
        public HRDbContext() : base("name=DefaultConnection")
        {

        }
        public DbSet<PersonalInformation> PersonalInfo { get; set; }

    }
}