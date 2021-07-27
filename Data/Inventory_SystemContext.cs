using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Inventory_System.Models;

namespace Inventory_System.Data
{
    public class Inventory_SystemContext : DbContext
    {
        public Inventory_SystemContext (DbContextOptions<Inventory_SystemContext> options)
            : base(options)
        {
        }

        public DbSet<Inventory_System.Models.Category> Category { get; set; }

        public DbSet<Inventory_System.Models.Product> Product { get; set; }

        public DbSet<Inventory_System.Models.Registeration> Registeration { get; set; }

        public DbSet<Inventory_System.Models.Retailer> Retailer { get; set; }
    }
}
