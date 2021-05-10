using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tp.Restaurante.Domain.DTOs;

namespace Tp.Restaurante.Domain.Queries
{
    public interface ITipoMercaderiaQuery
    {
        List<ResponseGetAllTipoMercaderia> GetAllTipoMercaderias();
    }
}
