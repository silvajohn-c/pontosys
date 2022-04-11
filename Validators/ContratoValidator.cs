using FluentValidation;
using pontosys.Domain.Entities;

namespace pontosys.Validators
{
    public class ContratoValidator : AbstractValidator<Contrato> 
    {
        public ContratoValidator()
        {
            RuleFor(x => x.DataInicio)
            .NotEmpty().WithMessage("A data de inicio do contrato não pode ser vazia.")
            .NotNull().WithMessage("Favor informar a data de início do contrato.");
        }
    }
}