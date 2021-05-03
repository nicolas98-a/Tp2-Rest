using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tp.Restaurante.Domain.Entities;

namespace Tp.Restaurante.Domain.Validation
{
    public class ComandaValidator : AbstractValidator<Comanda>
    {
        public ComandaValidator()
        {
            RuleFor(e => e.FormaEntregaId).InclusiveBetween(1, 3).WithMessage("Debe seleccionar entre 1 y 3");
            
        }
    }
}
