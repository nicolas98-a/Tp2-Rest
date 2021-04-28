using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tp.Restaurante.Domain.Entities
{
    public class FormaEntrega
    {
        public int FormaEntregaId { get; set; }

        public string Descripcion { get; set; }

        public ICollection<Comanda> ComandasNavigator { get; set; }
    }
}
