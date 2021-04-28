using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tp.Restaurante.Domain.Entities
{
    public class Mercaderia
    {
        public int MercaderiaId { get; set; }

        public string Nombre { get; set; }

        public int Precio { get; set; }

        public string Ingredientes { get; set; }

        public string Preparacion { get; set; }

        public string Imagen { get; set; }

        public int TipoMercaderiaId { get; set; }

        public TipoMercaderia TipoMercaderiaNavigator { get; set; }

        public IList<Comanda> ComandasNavigator { get; set; }
    }
}
