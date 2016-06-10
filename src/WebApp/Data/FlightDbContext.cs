using FlugDemo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlugDemo.Data
{
    public class FlightDbContext: DbContext
    {
        public DbSet<Flight> Flights { get; set; }

        public DbSet<Booking> Bookings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseInMemoryDatabase();
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\ProjectsV12;Initial Catalog=FlugDemoDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Flight>()
                .Property(f => f.From)
                .HasMaxLength(30)
                .IsRequired();

            modelBuilder.Entity<Flight>()
                        .HasMany(f => f.Bookings)
                        .WithOne(b => b.Flug)
                        .HasForeignKey(b => b.FlugId)
                        .OnDelete(DeleteBehavior.Cascade);

        }

    }
}
