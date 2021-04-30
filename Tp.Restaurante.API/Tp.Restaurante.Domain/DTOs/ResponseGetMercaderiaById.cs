﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tp.Restaurante.Domain.DTOs
{
    public class ResponseGetMercaderiaById
    {
        public string Nombre { get; set; }
        public string Tipo { get; set; }

        public int Precio { get; set; }

        public string Ingredientes { get; set; }

        public string Preparacion { get; set; }

        public string Imagen { get; set; }
        public int MercaderiaId { get; set; }
    }

    public class ResponseGetMercaderiaByIdTipo
    {
        public int TipoMercaderiaId { get; set; }

        public string Descripcion { get; set; }
    }
}