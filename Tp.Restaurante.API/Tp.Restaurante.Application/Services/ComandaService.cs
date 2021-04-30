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
    public interface IComandaService
    {
        GenericCreatedResponseDto CreateComanda(CreateComandaRequestDto comandaDto);
    }
    public class ComandaService : IComandaService
    {
        private readonly IGenericsRepository _repository;
        private readonly IMercaderiaService _mercaderiaService;
        public ComandaService(IGenericsRepository repository , IMercaderiaService mercaderiaService)
        {
            _repository = repository;
            _mercaderiaService = mercaderiaService;
        }

        public GenericCreatedResponseDto CreateComanda(CreateComandaRequestDto comandaDto)
        {
            List<ResponseGetMercaderiaById> listaMercaderias = new List<ResponseGetMercaderiaById>();
            foreach (var item in comandaDto.Mercaderias)
            {
                 ResponseGetMercaderiaById mercaderia = _mercaderiaService.GetById(item.ToString());
                listaMercaderias.Add(mercaderia);
            }
            int total = Calcularpreciototal(listaMercaderias); 
            var entity = new Comanda
            {
                ComandaId = new Guid(),
                FormaEntregaId = comandaDto.FormaEntrega,
                PrecioTotal = total,
                Fecha = new DateTime()

            };
            _repository.Add(entity);

            foreach (ResponseGetMercaderiaById item in listaMercaderias)
            {
                RegistrarComandaMercaderia(item.MercaderiaId, entity.ComandaId);
            }
            return new GenericCreatedResponseDto { Entity = "Comanda", Id = entity.ComandaId.ToString() };


        }

        public int Calcularpreciototal(List<ResponseGetMercaderiaById> mercaderias)
        {
            int total = 0;
            List<ResponseGetMercaderiaById> aux = mercaderias;
            foreach (var item in aux)
            {
                total += item.Precio;
            }
            return total;

        }

        private void RegistrarComandaMercaderia(int idMercaderia , Guid idComanda)
        {
            var entity = new ComandaMercaderia
            {

                MercaderiaId = idMercaderia,
                ComandaId = idComanda

            };
            _repository.Add(entity);
        }
    }
}
