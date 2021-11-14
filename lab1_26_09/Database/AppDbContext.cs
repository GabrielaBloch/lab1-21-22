using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lab1_26_09.Entities;
using Microsoft.EntityFrameworkCore;

namespace lab1_26_09.Database
{
    public class AppDbContext : DbContext
    {
        public DbSet<ProductEntity> Products { get; set; }

        public AppDbContext (DbContextOptions options) : base (options)
        {
        }

    }
}
