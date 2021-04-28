﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tp.Restaurante.Domain.Entities
{
    public class TipoMercaderia
    {
        public int TipoMercaderiaId { get; set; }

        public string Descripcion { get; set; }

        public ICollection<Mercaderia> MercaderiasNavigator { get; set; }
    }
}
