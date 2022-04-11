using pontosys.Domain.Entities;

namespace pontosys.Data.Repository
{
    public interface IRepository
    {
        void Add<T>(T entity) where T : class;
        Task<int> SaveChanges();
        Funcionario AddFuncionario(long cpf, string nome, string sobrenome);
        Cargo AddCargo(string cargo);
        Expediente AddExpediente(int cargaHoraria);
        ModalidadeContrato AddModalidadeContrato(string nome);
        Contrato AddContrato(Funcionario funcionario, Cargo cargo, Expediente expediente, ModalidadeContrato modalidadeContrato, DateTime inicioContrato, DateTime fimContrato);
        void AddRegistroPonto(DateTime data,string funcionarioId);

        string validationErrors(FluentValidation.Results.ValidationResult validatorResult);
    }
}