using System.Data.Entity;

namespace PoC.Microservice.Database
{
    public class HaromszogDbContext : DbContext
    {
        public HaromszogDbContext() : base("HaromszogDbContext")
        {
            
        }
        public virtual DbSet<HaromszogRecord> Haromszogek { get; set; }
    }
}
