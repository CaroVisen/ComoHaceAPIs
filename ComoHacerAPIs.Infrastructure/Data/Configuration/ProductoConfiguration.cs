using ComoHacerAPIs.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ComoHacerAPIs.Infrastructure.Data.Configuration
{
    public class ProductoConfiguration : IEntityTypeConfiguration<Producto>
    {
        public void Configure(EntityTypeBuilder<Producto> builder)
        {
            builder.ToTable("Producto").HasKey(x => x.id);
            //builder.Property(x => x.nombre).IsRequired();
        }
    }
}
