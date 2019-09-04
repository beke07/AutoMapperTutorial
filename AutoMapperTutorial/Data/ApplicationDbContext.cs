using AutoMapperTutorial.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutoMapperTutorial.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Ember> Emberek { get; set; }
        public DbSet<Leszarmazott> Leszarmazottak { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=AutoMapperDb;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var ember = new Ember()
            {
                Id = Guid.Parse("774d5bf8-d080-4a48-9e9a-bfa13a286781"),
                VezetekNev = "Kovács",
                KeresztNev = "József",
                Kor = 30
            };

            modelBuilder.Entity<Ember>().HasData(ember);
            modelBuilder.Entity<Leszarmazott>().HasData(new Leszarmazott()
            {
                Id = Guid.Parse("85474139-82ac-4d23-957d-255f7e799687"),
                VezetekNev = "Kovács",
                KeresztNev = "Ferenc",
                Kor = 6,
                HajSzin = "Barna",
                SzemSzin = "Kék"
            });
        }
    }
}
