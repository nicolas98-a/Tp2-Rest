using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tp.Restaurante.Domain.Entities;

namespace Tp.Restaurante.Domain.DTOs
{
    public class ResponseGetAllComandaDto
    {
        public Guid ComandaId { get; set; }

        public int PrecioTotal { get; set; }
        public DateTime Fecha { get; set; }

        public string FormaEntrega { get; set; }

        public string Mercaderia { get; set; }
    }
}
