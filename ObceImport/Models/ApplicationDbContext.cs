using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ObceImport.Models
{
    class ApplicationDbContext : DbContext
    {
        public DbSet<Region> Regions { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<Municipality> Municipalities { get; set; }
        public DbSet<Population> Populations { get; set; }
        public ApplicationDbContext() : base()
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseMySQL("server=localhost;database=piskoviste_obce_2020;user=root");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Population>().HasKey(p => new { p.LAU2, p.Year });
        }
    }
}
