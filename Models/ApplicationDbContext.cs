using Microsoft.EntityFrameworkCore;

namespace Homepage_NAVASCA.Models
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Register> Register { get; set; }

    }
}

