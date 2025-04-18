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

    public DbSet<Storage> Configs => Set<Storage>(); 
}
