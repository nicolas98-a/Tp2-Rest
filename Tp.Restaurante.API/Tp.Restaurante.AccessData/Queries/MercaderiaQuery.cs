using SqlKata.Compilers;
using SqlKata.Execution;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tp.Restaurante.Domain.DTOs;
using Tp.Restaurante.Domain.Queries;

namespace Tp.Restaurante.AccessData.Queries
{
    public class MercaderiaQuery : IMercaderiaQuery
    {
        private readonly IDbConnection connection;
        private readonly Compiler sqlKataCompiler;

        public MercaderiaQuery(IDbConnection connection, Compiler sqlKataCompiler)
        {
            this.connection = connection;
            this.sqlKataCompiler = sqlKataCompiler;
        }

        public ResponseGetMercaderiaById GetById(string mercaderiaId)
        {
            var db = new QueryFactory(connection, sqlKataCompiler);
            /*
            var mercaderia = db.Query("Mercaderias")
                .Select("Nombre", "Precio", "Ingredientes", "Preparacion", "Imagen", "TipoMercaderiaId")
                .Where("MercaderiaId", "=", mercaderiaId)
                .FirstOrDefault<MercaderiaDto>();

            string tipo = db.Query("TipoMercaderia")
                .Select("Descripcion")
                .Where("TipoMercaderiaId", "=", mercaderia.Tipo)
                .ToString();
                */
            var mercaderia = db.Query("Mercaderias")
                .Join("TipoMercaderia", "TipoMercaderia.TipoMercaderiaId", "Mercaderias.TipoMercaderiaId")
                .Where("MercaderiaId", "=", mercaderiaId)
                .Select(
                "Mercaderias.{Nombre, Precio, Ingredientes, Preparacion, Imagen}",
                "TipoMercaderia.{Descripcion}")
                .FirstOrDefault<ResponseGetMercaderiaById>();
            
                                  

            return new ResponseGetMercaderiaById
            {
                Nombre = mercaderia.Nombre,
                Tipo = mercaderia.Tipo,
                Precio = mercaderia.Precio,
                Ingredientes = mercaderia.Ingredientes,
                Preparacion = mercaderia.Preparacion,
                Imagen = mercaderia.Imagen
            };

        }
    }
}
