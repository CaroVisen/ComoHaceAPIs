using ComoHacerAPIs.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComoHacerAPIs.Infrastructure.Data.Configuration
{
    public class VendedorConfiguration : IEntityTypeConfiguration<Vendedor>
    {
        public void Configure(EntityTypeBuilder<Vendedor> builder)
        {
            builder.ToTable("Vendedor").HasKey(x => x.id);
               
        }
    }
}
