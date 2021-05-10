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
    public class TipoMercaderiaQuery : ITipoMercaderiaQuery
    {
        private readonly IDbConnection connection;
        private readonly Compiler sqlKataCompiler;

        public TipoMercaderiaQuery(IDbConnection connection, Compiler sqlKataCompiler)
        {
            this.connection = connection;
            this.sqlKataCompiler = sqlKataCompiler;
        }

        public List<ResponseGetAllTipoMercaderia> GetAllTipoMercaderias()
        {
            var db = new QueryFactory(connection, sqlKataCompiler);
            var query = db.Query("TipoMercaderia")
                .Select("TipoMercaderiaId", "Descripcion")
                .Get<ResponseGetAllTipoMercaderia>().ToList();

            return query;
        }
    }
}
