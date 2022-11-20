using KnowledgeHubPortalProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace KnowledgeHubPortalProject.Models
{
    public class KnowledgeHubDbContext : DbContext
    {
        //Configure the db
        public KnowledgeHubDbContext() : base("name=DefaultConnection")
        {

        }

        //configure the tables
        public DbSet<Category> Categories { get; set; }
        public DbSet<Article> Articles { get; set; }
    }
}