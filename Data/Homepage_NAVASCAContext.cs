using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Homepage_NAVASCA.Models;

namespace Homepage_NAVASCA.Data
{
    public class Homepage_NAVASCAContext : DbContext
    {
        public Homepage_NAVASCAContext (DbContextOptions<Homepage_NAVASCAContext> options)
            : base(options)
        {
        }

        public DbSet<Homepage_NAVASCA.Models.Product> Product { get; set; } = default!;
        public DbSet<Homepage_NAVASCA.Models.Register> Register { get; set; } = default!;
    }
}
