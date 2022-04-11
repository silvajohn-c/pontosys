using FluentValidation;
using pontosys.Domain.Entities;

namespace pontosys.Validators
{
    public class CargoValidator : AbstractValidator<Cargo> 
    {
        public CargoValidator()
        {
            RuleFor(x => x.Nome)
            .NotEmpty().WithMessage("O nome do funcionário não pode ser vazio.")
            .NotNull().WithMessage("Favor informar o nome do funcionário.");
        }
    }
}