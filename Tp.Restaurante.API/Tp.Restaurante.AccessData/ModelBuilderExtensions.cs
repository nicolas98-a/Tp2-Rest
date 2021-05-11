using Microsoft.EntityFrameworkCore;
using Tp.Restaurante.Domain.Entities;

namespace Tp.Restaurante.AccessData
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            //Cargo tipos de mercaderia en la tabla TipoMercaderia de la base de datos
            modelBuilder.Entity<TipoMercaderia>(entity =>
            {
                entity.ToTable("TipoMercaderia");
                entity.HasData(new TipoMercaderia
                {
                    TipoMercaderiaId = 1,
                    Descripcion = "Entrada"
                });
                entity.HasData(new TipoMercaderia
                {
                    TipoMercaderiaId = 2,
                    Descripcion = "Minutas"
                });
                entity.HasData(new TipoMercaderia
                {
                    TipoMercaderiaId = 3,
                    Descripcion = "Pastas"
                });
                entity.HasData(new TipoMercaderia
                {
                    TipoMercaderiaId = 4,
                    Descripcion = "Parrilla"
                });
                entity.HasData(new TipoMercaderia
                {
                    TipoMercaderiaId = 5,
                    Descripcion = "Pizzas"
                });
                entity.HasData(new TipoMercaderia
                {
                    TipoMercaderiaId = 6,
                    Descripcion = "Sandwich"
                });
                entity.HasData(new TipoMercaderia
                {
                    TipoMercaderiaId = 7,
                    Descripcion = "Ensaladas"
                });
                entity.HasData(new TipoMercaderia
                {
                    TipoMercaderiaId = 8,
                    Descripcion = "Bebidas"
                });
                entity.HasData(new TipoMercaderia
                {
                    TipoMercaderiaId = 9,
                    Descripcion = "Cerveza Artesanal"
                });
                entity.HasData(new TipoMercaderia
                {
                    TipoMercaderiaId = 10,
                    Descripcion = "Postres"
                });
            });

            //Cargo formas de entrge a la tabla FormEntrega de la base de datos
            modelBuilder.Entity<FormaEntrega>(entity =>
            {
                entity.ToTable("FormaEntrega");
                entity.HasData(new FormaEntrega
                {
                    FormaEntregaId = 1,
                    Descripcion = "Salon"
                });
                entity.HasData(new FormaEntrega
                {
                    FormaEntregaId = 2,
                    Descripcion = "Delivery"
                });
                entity.HasData(new FormaEntrega
                {
                    FormaEntregaId = 3,
                    Descripcion = "Pedidos Ya"
                });


            });
        }
    }
}
