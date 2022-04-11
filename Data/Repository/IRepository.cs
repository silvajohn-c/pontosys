using pontosys.Domain.Entities;

namespace pontosys.Data.Repository
{
    public interface IRepository
    {
        void Add<T>(T entity) where T : class;
        Task<int> SaveChanges();
        Funcionario GetFuncionario(long cpf, string nome, string sobrenome);
        Cargo GetCargo(string cargo);
        Expediente GetExpediente(int cargaHoraria);
        ModalidadeContrato GetModalidadeContrato(string nome);
        Contrato GetContrato(Funcionario funcionario, Cargo cargo, Expediente expediente, ModalidadeContrato modalidadeContrato, DateTime inicioContrato, DateTime fimContrato);
        void AddRegistroPonto(DateTime data,string funcionarioId);
        string GetValidationErrors(FluentValidation.Results.ValidationResult validatorResult);
    }
}