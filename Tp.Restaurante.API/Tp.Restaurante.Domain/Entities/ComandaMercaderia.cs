using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tp.Restaurante.Domain.Entities
{
    public class ComandaMercaderia
    {
        public int ComandaMercaderiaId { get; set; }

        public int MercaderiaId { get; set; }
        public Mercaderia MercaderiaNavigator { get; set; }

        public Guid ComandaId { get; set; }
        public Comanda ComandaNavigator { get; set; }
    }
}
