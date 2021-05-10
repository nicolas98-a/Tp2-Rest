using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tp.Restaurante.Domain.DTOs
{
    public class ResponseGetAllTipoMercaderia
    {
        public int TipoMercaderiaId { get; set; }

        public string Descripcion { get; set; }
    }
}
