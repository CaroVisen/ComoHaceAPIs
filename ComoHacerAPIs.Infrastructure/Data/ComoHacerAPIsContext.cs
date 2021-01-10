using ComoHacerAPIs.Core.Entities;
using ComoHacerAPIs.Infrastructure.Data.Configuration;
using Microsoft.EntityFrameworkCore;

namespace ComoHacerAPIs.Infrastructure.Data
{
    public class ComoHacerAPIsContext : DbContext
    {
        public ComoHacerAPIsContext()
        {
        }
        public ComoHacerAPIsContext(DbContextOptions<ComoHacerAPIsContext> options) : base(options)
        {
        }

        public virtual DbSet<Producto> Productos { get; set; }
        public virtual DbSet<Vendedor> Vendedor { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductoConfiguration());
            //aca van las otras tablas
        }
    }
}
