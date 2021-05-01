using SqlKata.Compilers;
using SqlKata.Execution;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tp.Restaurante.Application.Services;
using Tp.Restaurante.Domain.DTOs;
using Tp.Restaurante.Domain.Queries;

namespace Tp.Restaurante.AccessData.Queries
{
    public class ComandaQuery : IComandaQuery
    {
        private readonly IDbConnection connection;
        private readonly Compiler sqlKataCompiler;
        private readonly IMercaderiaService _mercaderiaservice;

        public ComandaQuery(IDbConnection connection, Compiler sqlKataCompiler, IMercaderiaService service)
        {
            this.connection = connection;
            this.sqlKataCompiler = sqlKataCompiler;
            _mercaderiaservice = service;
        }

        public List<ResponseGetAllComandaDto> GetAllComanda(string fecha)
        {   
            var db = new QueryFactory(connection, sqlKataCompiler);
            
            var query = db.Query("Comandas")
                .Select("Comandas.ComandaId",
                "Comandas.PrecioTotal",
                "Comandas.Fecha",
                "FormaEntrega.Descripcion AS FormaEntrega",
                "Mercaderias.Nombre AS Mercaderia")
                .Join("FormaEntrega", "FormaEntrega.FormaEntregaId", "Comandas.FormaEntregaId")
                .Join("ComandaMercaderias", "ComandaMercaderias.ComandaId", "Comandas.ComandaId")
                .Join("Mercaderias", "Mercaderias.MercaderiaId", "ComandaMercaderias.MercaderiaId")
                .When(!string.IsNullOrWhiteSpace(fecha), q => q.WhereLike("Comandas.Fecha", $"%{fecha}%"));
            var result = query.Get<ResponseGetAllComandaDto>();
            return result.ToList();
        }

        public ResponseGetComandaById GetById(string comandaId)
        {
            var db = new QueryFactory(connection, sqlKataCompiler);

            var comanda = db.Query("Comandas")
                .Select("ComandaId", "PrecioTotal", "Fecha", "FormaEntregaId")
                .Where("ComandaId", "=", comandaId)
                .FirstOrDefault<ComandaDto>();

            var entrega = db.Query("FormaEntrega")
                .Select("FormaEntregaId", "Descripcion")
                .Where("FormaEntregaId", "=", comanda.FormaEntregaId)
                .FirstOrDefault<ResponseGetComandaByIdFormaEntrega>();

            var idsMercaderia = db.Query("ComandaMercaderias")
                .Select("MercaderiaId", "ComandaId")
                .Where("ComandaId", "=", comandaId)
                .Get<int>().ToList();

            List<ResponseGetMercaderiaById> listaMercaderias = new List<ResponseGetMercaderiaById>();
            foreach (var item in idsMercaderia)
            {
                ResponseGetMercaderiaById mercaderia = _mercaderiaservice.GetById(item.ToString());
                listaMercaderias.Add(mercaderia);
            }

            return new ResponseGetComandaById
            {
                ComandaId = comanda.ComandaId,
                PrecioTotal = comanda.PrecioTotal,
                Fecha = comanda.Fecha,
                FormaEntrega = entrega.Descripcion,
                Mercaderia = listaMercaderias
            };

        }
    }
}
