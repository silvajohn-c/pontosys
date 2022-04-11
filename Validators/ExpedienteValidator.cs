using FluentValidation;
using pontosys.Domain.Entities;

namespace pontosys.Validators
{
    public class ExpedienteValidator : AbstractValidator<Expediente> 
    {
        public ExpedienteValidator()
        {
            RuleFor(x => x.CargaHoraria)
            .NotEmpty().WithMessage("A carga horária não pode ser vazia.")
            .NotNull().WithMessage("Favor informar a carga horária.");
        }
    }
}