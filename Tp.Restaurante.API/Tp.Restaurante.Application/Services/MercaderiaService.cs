using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tp.Restaurante.Domain.Commands;
using Tp.Restaurante.Domain.DTOs;
using Tp.Restaurante.Domain.Entities;
using Tp.Restaurante.Domain.Queries;
using Tp.Restaurante.Domain.Validation;

namespace Tp.Restaurante.Application.Services
{   
    public interface IMercaderiaService
    {
        GenericCreatedResponseDto CreateMercaderia(MercaderiaDto mercaderia);
        bool UpdateMercaderia(int id, MercaderiaDto mercaderiaDto);
        bool DeleteMercaderia(int id);
        List<ResponseGetAllMercaderiaDto> GetMercaderias(string tipo);
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
            MercaderiaValidator validator = new MercaderiaValidator();
            validator.ValidateAndThrow(entity);
           
            _repository.Add<Mercaderia>(entity);
            return new GenericCreatedResponseDto { Entity = "Mercaderia", Id = entity.MercaderiaId.ToString() };

        }

        public List<ResponseGetAllMercaderiaDto> GetMercaderias(string tipo)
        {
            return _query.GetAllMercaderia(tipo);
        }

        public ResponseGetMercaderiaById GetById(string mercaderiaId)
        {
            return _query.GetById(mercaderiaId);
        }

        public bool UpdateMercaderia(int id, MercaderiaDto mercaderiaDto)
        {
            Mercaderia mercaderia = _repository.Exists<Mercaderia>(id);
            if (mercaderia == null)
            {
                return false;
            }
            else
            {
              
                mercaderia.Nombre = mercaderiaDto.Nombre;
                mercaderia.TipoMercaderiaId = mercaderiaDto.TipoMercaderiaId;
                mercaderia.Precio = mercaderiaDto.Precio;
                mercaderia.Ingredientes = mercaderiaDto.Ingredientes;
                mercaderia.Preparacion = mercaderiaDto.Preparacion;
                mercaderia.Imagen = mercaderiaDto.Imagen;

                MercaderiaValidator validator = new MercaderiaValidator();
                validator.ValidateAndThrow(mercaderia);

                _repository.Update<Mercaderia>(mercaderia);

                return true;

            }
        }

        public bool DeleteMercaderia(int id)
        {
            Mercaderia mercaderia = _repository.Exists<Mercaderia>(id);
            if (mercaderia == null)
            {
                return false;
            }
            else
            {
                _repository.Delete<Mercaderia>(mercaderia);

                return true;
            }

        }
    }
}
