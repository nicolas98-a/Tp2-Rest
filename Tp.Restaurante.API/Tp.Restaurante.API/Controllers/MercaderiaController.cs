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
        [ProducesResponseType(typeof(Mercaderia), StatusCodes.Status201Created)]
        public IActionResult Post(MercaderiaDto mercaderia)
        {
            try
            {
                return new JsonResult(_service.CreateMercaderia(mercaderia)) { StatusCode = 201 };

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            
        }

        [HttpGet("{Id}")]
        [ProducesResponseType(typeof(ResponseGetMercaderiaById), StatusCodes.Status200OK)]
        public IActionResult GetMercaderiaById(string Id)
        {
            try
            {
                return new JsonResult(_service.GetById(Id)) { StatusCode = 200 };
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
