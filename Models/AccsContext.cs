using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_fvg.Models
{
    public class AccsContext : DbContext
    {
        public DbSet<Acc> Accs { get; set; }
        public AccsContext(DbContextOptions<AccsContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
