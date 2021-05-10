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
    public class FormaEntregaQuery : IFormaEntregaQuery
    {
        private readonly IDbConnection connection;
        private readonly Compiler sqlKataCompiler;

        public FormaEntregaQuery(IDbConnection connection, Compiler sqlKataCompiler)
        {
            this.connection = connection;
            this.sqlKataCompiler = sqlKataCompiler;
        }

        public List<ResponseGetAllFormaEntrega> GetAllFormaEntregas()
        {
            var db = new QueryFactory(connection, sqlKataCompiler);
            var query = db.Query("FormaEntrega")
                .Select("FormaEntregaId", "Descripcion")
                .Get<ResponseGetAllFormaEntrega>().ToList();

            return query;

        }
    }
}
