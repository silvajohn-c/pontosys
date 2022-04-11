using FluentValidation;
using pontosys.Domain.Entities;

namespace pontosys.Validators
{
    public class ModalidadeContratoValidator : AbstractValidator<ModalidadeContrato> 
    {
        public ModalidadeContratoValidator()
        {
            RuleFor(x => x.Nome)
            .NotEmpty().WithMessage("O nome da modalidade de contrato não pode ser vazio.")
            .NotNull().WithMessage("Favor informar o nome da modalidade de contrato.");
        }
    }
}