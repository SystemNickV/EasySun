﻿using EasySun.Models;
using Microsoft.EntityFrameworkCore;

namespace EasySun.Database
{
    /// <summary>
    /// Represents project's DB Context.
    /// </summary>
    public sealed class SunDbContext : DbContext
    {
        public SunDbContext(DbContextOptions<SunDbContext> options)
            : base(options)
        {
            // Please use migrations in production after deployment.
            // EnsureCreated() can't be used with migrations and should be used only on development stage.
            // See https://docs.microsoft.com/en-us/aspnet/core/data/ef-rp/migrations?view=aspnetcore-5.0&tabs=visual-studio#remove-ensurecreated
            // Database.EnsureCreated(); is called in DbInitializer class on app start
        }

        public DbSet<Country> Countries { get; set; }

        public DbSet<City> Cities { get; set; }

        public DbSet<EventTime> EventTimes { get; set; }

        // Fluent API config that better be here than in data annotations
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("sun");

            modelBuilder.Entity<Country>()
                .HasIndex(c => c.Name)
                .IsUnique();

            modelBuilder.Entity<City>()
                .HasIndex(c => c.Name)
                .IsUnique();

            modelBuilder.Entity<City>()
                .HasOne(city => city.Country)
                .WithMany(country => country.Cities)
                .HasForeignKey(city => city.CountryFK)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            modelBuilder.Entity<EventTime>()
                .HasOne(e => e.City)
                .WithMany(c => c.EventTimings)
                .HasForeignKey(e => e.CityFK)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();
        }
    }
}
