using FluentValidation;
using pontosys.Domain.Entities;
using pontosys.Domain.Models;

namespace pontosys.Validators
{
    public class XlsValidator : AbstractValidator<XlsModel> 
    {
        public XlsValidator()
        {
            RuleFor(x => x.Nome)
            .NotEmpty().WithMessage("Nome não pode ser vazio.")
            .NotNull().WithMessage("Favor informar o nome do funcionário.")
            .Length(2, 250).WithMessage("Tamanho do nome inválido");

            RuleFor(x => x.Sobrenome)
            .NotEmpty().WithMessage("Sobrenome não pode ser vazio.")
            .NotNull().WithMessage("Favor informar o Sobrenome do funcionário.")
            .Length(2, 250).WithMessage("Tamanho do Sobrenome inválido");

            RuleFor(x => x.Cpf.ToString())
            .NotEmpty().WithMessage("Cpf não pode ser vazio.")
            .NotNull().WithMessage("Favor informar o Cpf do funcionário.")
            .Length(11).WithMessage("Tamanho do Cpf inválido");

            RuleFor(x => x.Cargo)
            .NotEmpty().WithMessage("O cargo do funcionário não pode ser vazio.")
            .NotNull().WithMessage("Favor informar o cargo do funcionário.");

            RuleFor(x => x.CargaHoraria)
            .NotEmpty().WithMessage("A carga horária não pode ser vazia.")
            .NotNull().WithMessage("Favor informar a carga horária.");

            RuleFor(x => x.ModalidadeContrato)
            .NotEmpty().WithMessage("O nome da modalidade de contrato não pode ser vazio.")
            .NotNull().WithMessage("Favor informar o nome da modalidade de contrato.");

            RuleFor(x => x.InicioContrato)
            .NotEmpty().WithMessage("A data de inicio do contrato não pode ser vazia.")
            .NotNull().WithMessage("Favor informar a data de início do contrato.");
        }
    }
}