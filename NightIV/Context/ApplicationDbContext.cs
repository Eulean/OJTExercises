using NightIV.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace NightIV.Context
{
    public class ApplicationDbContext : DbContext
    {
        
            public DbSet<Customer> Customers { get; set; }
            public DbSet<Movie> Movies { get; set; }
        
    }
}