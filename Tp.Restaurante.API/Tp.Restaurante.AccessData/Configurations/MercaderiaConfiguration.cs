using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tp.Restaurante.Domain.Entities;

namespace Tp.Restaurante.AccessData.Configurations
{
    public class MercaderiaConfiguration
    {
        public MercaderiaConfiguration(EntityTypeBuilder<Mercaderia> entityTypeBuilder)
        {
            entityTypeBuilder.Property(x => x.Nombre).IsRequired().HasMaxLength(50);
            entityTypeBuilder.Property(x => x.Ingredientes).IsRequired().HasMaxLength(255);
            entityTypeBuilder.Property(x => x.Preparacion).IsRequired().HasMaxLength(255);
            entityTypeBuilder.Property(x => x.Imagen).IsRequired().HasMaxLength(255);
        }
    }
}
