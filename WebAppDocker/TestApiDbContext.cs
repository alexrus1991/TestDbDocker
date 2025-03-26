using Microsoft.EntityFrameworkCore;
using WebAppDocker.Models;

namespace WebAppDocker
{
    public class TestApiDbContext : DbContext
    {
        public TestApiDbContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Produit> Produits { get { return Set<Produit>(); } }
    }
}
