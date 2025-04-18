using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConfigLibrary.Models;
using Microsoft.EntityFrameworkCore;


namespace ConfigLibrary.Data;

public class ConfigDbContext : DbContext
{
    public ConfigDbContext(DbContextOptions<ConfigDbContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Storage>().HasData(
            new Storage
            {
                Id = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                Name = "SiteName",
                Type = "string",
                Value = "soty.io",
                IsActive = true,
                ApplicationName = "SERVICE-A",
                LastModified = DateTime.Now
            },
            new Storage
            {
                Id = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                Name = "IsBasketEnabled",
                Type = "bool",
                Value = "1",
                IsActive = true,
                ApplicationName = "SERVICE-B",
                LastModified = DateTime.Now
            },
            new Storage
            {
                Id = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                Name = "MaxItemCount",
                Type = "int",
                Value = "50",
                IsActive = false,
                ApplicationName = "SERVICE-A",
                LastModified = DateTime.Now
            }
            );
    }

    public DbSet<Storage> Configs => Set<Storage>(); 
}
