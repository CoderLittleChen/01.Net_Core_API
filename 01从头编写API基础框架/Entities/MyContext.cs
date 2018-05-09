using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Net_Core_API.Entities
{
    public class MyContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
    }
}
