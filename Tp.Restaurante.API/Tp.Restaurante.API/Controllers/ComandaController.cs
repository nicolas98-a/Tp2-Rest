﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tp.Restaurante.Application.Services;
using Tp.Restaurante.Domain.DTOs;

namespace Tp.Restaurante.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComandaController : ControllerBase
    {
        private readonly IComandaService _service;
        public ComandaController(IComandaService service)
        {
            _service = service;
        }

        [HttpPost]
        [ProducesResponseType(typeof(GenericCreatedResponseDto), StatusCodes.Status201Created)]
        public IActionResult Post(CreateComandaRequestDto comanda)
        {
            try
            {
                return new JsonResult(_service.CreateComanda(comanda)) { StatusCode = 201 };
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}