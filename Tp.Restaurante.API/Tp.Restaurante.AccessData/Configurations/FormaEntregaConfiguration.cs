using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tp.Restaurante.Domain.Entities;

namespace Tp.Restaurante.AccessData.Configurations
{
    public class FormaEntregaConfiguration
    {
        public FormaEntregaConfiguration(EntityTypeBuilder<FormaEntrega> entityTypeBuilder)
        {
            entityTypeBuilder.Property(x => x.Descripcion).IsRequired().HasMaxLength(50);
        }
    }
}
