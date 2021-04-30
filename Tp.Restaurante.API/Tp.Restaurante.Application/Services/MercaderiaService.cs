﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tp.Restaurante.Domain.Commands;
using Tp.Restaurante.Domain.DTOs;
using Tp.Restaurante.Domain.Entities;
using Tp.Restaurante.Domain.Queries;

namespace Tp.Restaurante.Application.Services
{   
    public interface IMercaderiaService
    {
        GenericCreatedResponseDto CreateMercaderia(MercaderiaDto mercaderia);
        ResponseGetMercaderiaById GetById(string mercaderiaId);
    }
    public class MercaderiaService : IMercaderiaService
    {
        private readonly IGenericsRepository _repository;
        private readonly IMercaderiaQuery _query;
        public MercaderiaService (IGenericsRepository repository, IMercaderiaQuery query)
        {
            _repository = repository;
            _query = query;
        }

        public GenericCreatedResponseDto CreateMercaderia(MercaderiaDto mercaderia)
        {
            var entity = new Mercaderia
            {
                Nombre = mercaderia.Nombre,
                TipoMercaderiaId = mercaderia.TipoMercaderiaId,
                Precio = mercaderia.Precio,
                Ingredientes = mercaderia.Ingredientes,
                Preparacion = mercaderia.Preparacion,
                Imagen = mercaderia.Imagen 
                
            };
            _repository.Add<Mercaderia>(entity);
            return new GenericCreatedResponseDto { Entity = "Mercaderia", Id = entity.MercaderiaId.ToString() };

        }

        public ResponseGetMercaderiaById GetById(string mercaderiaId)
        {
            return _query.GetById(mercaderiaId);
        }
    }
}
