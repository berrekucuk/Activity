using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Activity.DAL.ORM
{
    public class ActivityDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=LAPTOP-2K18C6FK\\SQLEXPRESS05;Database=ActivityDb;Trusted_Connection=True;TrustServerCertificate=True");
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }

    }
}
