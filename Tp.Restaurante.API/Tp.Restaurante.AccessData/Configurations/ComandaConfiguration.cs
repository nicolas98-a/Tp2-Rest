using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tp.Restaurante.Domain.Entities;

namespace Tp.Restaurante.AccessData.Configurations
{
    public class ComandaConfiguration
    {
        public ComandaConfiguration(EntityTypeBuilder<Comanda> entityTypeBuilder)
        {
            entityTypeBuilder.Property(x => x.ComandaId).IsRequired();
            entityTypeBuilder.Property(x => x.Fecha).HasDefaultValueSql("getdate()");
        }
    }
}
