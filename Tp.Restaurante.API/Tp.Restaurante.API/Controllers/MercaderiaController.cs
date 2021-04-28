using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tp.Restaurante.Application.Services;
using Tp.Restaurante.Domain.DTOs;
using Tp.Restaurante.Domain.Entities;

namespace Tp.Restaurante.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MercaderiaController : ControllerBase
    {
        private readonly IMercaderiaService _service;
        public MercaderiaController (IMercaderiaService service)
        {
            _service = service;
        }

        [HttpPost]
        public Mercaderia Post (MercaderiaDto mercaderia)
        {
            return _service.CreateMercaderia(mercaderia);
        }
    }
}
