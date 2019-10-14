using System;
using CheeseMVCPersistent.Models;
using Microsoft.EntityFrameworkCore;

namespace CheeseMVCPersistent.Data
{
    public class CheeseDbContext : DbContext
    {
        //tables
        public DbSet<Cheese> Cheeses { get; set; }
        public DbSet<CheeseCategory> Categories { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<CheeseMenu> CheeseMenus { get; set; }


        public CheeseDbContext(DbContextOptions<CheeseDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CheeseMenu>()
                .HasKey(c => new { c.CheeseID, c.MenuID });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost,1433; Database=CheeseDb2;User=SA; Password=<SHINee5252008>");
            //optionsBuilder.UseSqlServer("Server=localhost:8889; Database=CheeseMVC; User=CheeseMVC; Password=cheese");

        }
    }
}
