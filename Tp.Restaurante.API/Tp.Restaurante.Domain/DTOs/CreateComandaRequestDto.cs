using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tp.Restaurante.Domain.DTOs
{
    public class CreateComandaRequestDto
    {
        public List<int> Mercaderias { get; set; }
        public int FormaEntrega { get; set; }
    }
}
