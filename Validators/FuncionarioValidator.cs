using FluentValidation;
using pontosys.Domain.Entities;

namespace pontosys.Validators
{
    public class FuncionarioValidator : AbstractValidator<Funcionario> 
    {
        public FuncionarioValidator()
        {
            RuleFor(x => x.Nome)
            .NotEmpty().WithMessage("Nome não pode ser vazio.")
            .NotNull().WithMessage("Favor informar o nome do funcionário.")
            .Length(2, 250).WithMessage("Tamanho do nome inválido");
            
            RuleFor(x => x.Sobrenome)
            .NotEmpty().WithMessage("Sobrenome não pode ser vazio.")
            .NotNull().WithMessage("Favor informar o Sobrenome do funcionário.")
            .Length(2, 250).WithMessage("Tamanho do Sobrenome inválido");
        }
    }
}