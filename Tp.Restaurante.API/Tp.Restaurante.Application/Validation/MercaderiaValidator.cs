using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tp.Restaurante.Domain.DTOs;
using Tp.Restaurante.Domain.Entities;

namespace Tp.Restaurante.Application.Validation
{
    public class MercaderiaValidator : AbstractValidator<MercaderiaDto>
    {
        public MercaderiaValidator()
        {
            RuleFor(e => e.Nombre).NotNull().NotEmpty().WithMessage("El campo nombre no puede ser vacio");
            RuleFor(e => e.Nombre).MaximumLength(50).WithMessage("Cantidad de caracteres del nombre excedido");
            RuleFor(e => e.Ingredientes).NotNull().NotEmpty().WithMessage("El campo ingredientes no pude quedar vacio");
            RuleFor(e => e.Ingredientes).MaximumLength(255).WithMessage("Cantidad de caracteres de ingredientes excedido");
            RuleFor(e => e.Preparacion).NotNull().NotEmpty().WithMessage("El campo preparacion no puede quedar vacio");
            RuleFor(e => e.Preparacion).MaximumLength(255).WithMessage("Cantidad de caracteres de preparacion excedidos");
            RuleFor(e => e.Imagen).NotNull().NotEmpty().WithMessage("El campo imagen no puede quedar vacio");
            RuleFor(e => e.Imagen).MaximumLength(255).WithMessage("Cantidad de caracteres de imagen excedida");
            RuleFor(e => e.Precio).GreaterThan(-1).WithMessage("El precio del producto debe ser igual o mayor que cero");
          

        }
    }
}
