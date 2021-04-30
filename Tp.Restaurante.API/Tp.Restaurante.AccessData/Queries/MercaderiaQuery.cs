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
            
            var mercaderia = db.Query("Mercaderias")
                .Select("Nombre", "TipoMercaderiaId", "Precio", "Ingredientes", "Preparacion", "Imagen")
                .Where("MercaderiaId", "=", mercaderiaId)
                .FirstOrDefault<MercaderiaDto>();

            var tipo = db.Query("TipoMercaderia")
                .Select("TipoMercaderiaId", "Descripcion")
                .Where("TipoMercaderiaId", "=", mercaderia.TipoMercaderiaId)
                .FirstOrDefault<ResponseGetMercaderiaByIdTipo>();

            /*
            var mercaderia = db.Query("Mercaderias")
                .Join("TipoMercaderia", "TipoMercaderia.TipoMercaderiaId", "Mercaderias.TipoMercaderiaId")
                .Where("MercaderiaId", "=", mercaderiaId)
                .Select(
                "Mercaderias.{Nombre, Precio, Ingredientes, Preparacion, Imagen}",
                "TipoMercaderia.{Descripcion}")
                .FirstOrDefault<ResponseGetMercaderiaById>();
            
                    */

            return new ResponseGetMercaderiaById
            {
                Nombre = mercaderia.Nombre,
                Tipo = tipo.Descripcion,
                Precio = mercaderia.Precio,
                Ingredientes = mercaderia.Ingredientes,
                Preparacion = mercaderia.Preparacion,
                Imagen = mercaderia.Imagen,
                MercaderiaId = int.Parse(mercaderiaId)
            };

        }
    }
}
