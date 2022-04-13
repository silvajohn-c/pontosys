using pontosys.Data.Context;
using pontosys.Domain.Entities;

namespace pontosys.Data.Repository
{
    public class Repository : IRepository
    {
        private readonly PontosysContext context;

        public Repository(PontosysContext context)
        {
            this.context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            this.context.Add(entity);
        }
        public Task<int> SaveChanges()
        {
            return this.context.SaveChangesAsync();
        }
        public Funcionario GetFuncionario(long cpf)
        {

            foreach (var entity in this.context.Funcionarios.Local)
            {
                if(cpf == entity.Cpf) return entity;
            }

            Funcionario funcionario = this.context.Funcionarios.FirstOrDefault(x => x.Cpf.Equals(cpf));
                
            return funcionario;
        }
        public Cargo GetCargo(string nome)
        {
            foreach (var entity in this.context.Cargos.Local)
            {
                if(nome == entity.Nome) return entity;
            }

            Cargo cargo = this.context.Cargos.FirstOrDefault(x => x.Nome == nome);

            return cargo;
        }

        public Expediente GetExpediente(int cargaHoraria)
        {
            foreach (var entity in this.context.Expedientes.Local)
            {
                if(cargaHoraria == entity.CargaHoraria) return entity;
            }

            Expediente expediente = this.context.Expedientes.FirstOrDefault(x => x.CargaHoraria == cargaHoraria);
            
            return expediente;
        }

        public ModalidadeContrato GetModalidadeContrato(string nome)
        {
            foreach (var entity in this.context.ModalidadesContratos.Local)
            {
                if(nome == entity.Nome) return entity;
            }
            
            ModalidadeContrato modalidadeContrato = this.context.ModalidadesContratos.FirstOrDefault(x => x.Nome == nome);

            return modalidadeContrato;
        }

        public Contrato GetContrato(Funcionario funcionario, Cargo cargo, Expediente expediente, ModalidadeContrato modalidadeContrato, DateTime inicioContrato)
        {
            if(cargo != null && modalidadeContrato != null && expediente != null)
            {
                foreach (var entity in this.context.Contratos.Local)
                {
                    if(entity.FuncionarioId == funcionario.Id && entity.CargoId == cargo.Id && entity.ExpedienteId == expediente.Id && entity.ModalidadeContratoId == modalidadeContrato.Id && entity.DataInicio == inicioContrato)
                    return entity;
                }

                Contrato contrato = this.context.Contratos.FirstOrDefault(x => x.FuncionarioId == funcionario.Id && x.CargoId == cargo.Id && x.ExpedienteId == expediente.Id && x.ModalidadeContratoId == modalidadeContrato.Id && x.DataInicio == inicioContrato);

                return contrato;
            }

            Contrato nulo = null;
            return nulo;
        }
        public void AddRegistroPonto(DateTime data, string funcionarioId)
        {
                foreach (var entity in this.context.RegistrosPontos.Local)
                {
                    if(entity.CreatedAt == data && entity.FuncionarioId == funcionarioId) return;
                }

                RegistroPonto registroPonto = this.context.RegistrosPontos.FirstOrDefault(x => x.CreatedAt == data && x.FuncionarioId == funcionarioId);

                if (registroPonto == null)
                {
                    registroPonto = new RegistroPonto();
                    registroPonto.CreatedAt = data;
                    registroPonto.FuncionarioId = funcionarioId;
                    this.context.Add(registroPonto);
                }
        }

        public string GetValidationErrors(FluentValidation.Results.ValidationResult validatorResult)
        {
            string erros = "";
            
            foreach (var item in validatorResult.Errors)
            {
                erros += item.ErrorMessage + "\n";
            }

            return erros;
        }
    }
}