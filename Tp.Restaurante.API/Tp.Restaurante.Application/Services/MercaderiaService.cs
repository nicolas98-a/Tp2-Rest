using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tp.Restaurante.Domain.Commands;
using Tp.Restaurante.Domain.DTOs;
using Tp.Restaurante.Domain.Entities;

namespace Tp.Restaurante.Application.Services
{   
    public interface IMercaderiaService
    {
        Mercaderia CreateMercaderia(MercaderiaDto mercaderia);
    }
    public class MercaderiaService : IMercaderiaService
    {
        private readonly IGenericsRepository _repository;
        public MercaderiaService (IGenericsRepository repository)
        {
            _repository = repository;
        }

        public Mercaderia CreateMercaderia(MercaderiaDto mercaderia)
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
            return entity;

        }
    }
}
