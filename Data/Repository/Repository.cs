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
        public Funcionario AddFuncionario(long cpf, string nome, string sobrenome)
        {

            foreach (var entity in this.context.Funcionarios.Local)
            {
                if(cpf == entity.Cpf) return entity;
            }

            Funcionario funcionario = this.context.Funcionarios.FirstOrDefault(x => x.Cpf.Equals(cpf));

            if (funcionario == null)
            {                            
                funcionario = new Funcionario();
                funcionario.Cpf = cpf;
                funcionario.Nome = nome;
                funcionario.Sobrenome = sobrenome;
                this.context.Add(funcionario);
            }
                
            return funcionario;
        }
        public Cargo AddCargo(string nome)
        {
            foreach (var entity in this.context.Cargos.Local)
            {
                if(nome == entity.Nome) return entity;
            }

            Cargo cargo = this.context.Cargos.FirstOrDefault(x => x.Nome == nome);

            if (cargo == null && !String.IsNullOrEmpty(nome))
            {
                cargo = new Cargo();
                cargo.Nome = nome;
                this.context.Add(cargo);
            }

            return cargo;
        }

        public Expediente AddExpediente(int cargaHoraria)
        {
            foreach (var entity in this.context.Expedientes.Local)
            {
                if(cargaHoraria == entity.CargaHoraria) return entity;
            }

            Expediente expediente = this.context.Expedientes.FirstOrDefault(x => x.CargaHoraria == cargaHoraria);

            if (expediente == null && cargaHoraria != default(int))
            {
                expediente = new Expediente();
                expediente.CargaHoraria = cargaHoraria;
                this.context.Add(expediente);
            }
            
            return expediente;
        }

        public ModalidadeContrato AddModalidadeContrato(string nome)
        {
            foreach (var entity in this.context.ModalidadesContratos.Local)
            {
                if(nome == entity.Nome) return entity;
            }
            
            ModalidadeContrato modalidadeContrato = this.context.ModalidadesContratos.FirstOrDefault(x => x.Nome == nome);

            if (modalidadeContrato == null && !String.IsNullOrEmpty(nome))
            {
                modalidadeContrato = new ModalidadeContrato();
                modalidadeContrato.Nome = nome;
                this.context.Add(modalidadeContrato);
            }

            return modalidadeContrato;
        }

        public Contrato AddContrato(Funcionario funcionario, Cargo cargo, Expediente expediente, ModalidadeContrato modalidadeContrato, DateTime inicioContrato, DateTime fimContrato)
        {
            if(cargo != null && modalidadeContrato != null && expediente != null)
            {
                foreach (var entity in this.context.Contratos.Local)
                {
                    if(entity.FuncionarioId == funcionario.Id && entity.CargoId == cargo.Id && entity.ExpedienteId == expediente.Id && entity.ModalidadeContratoId == modalidadeContrato.Id && entity.DataInicio == inicioContrato)
                    return entity;
                }

                Contrato contrato = this.context.Contratos.FirstOrDefault(x => x.FuncionarioId == funcionario.Id && x.CargoId == cargo.Id && x.ExpedienteId == expediente.Id && x.ModalidadeContratoId == modalidadeContrato.Id && x.DataInicio == inicioContrato);
                
                if (contrato == null && inicioContrato != default(DateTime))
                {
                    contrato = new Contrato();
                    contrato.FuncionarioId = funcionario.Id;
                    contrato.CargoId = cargo.Id;
                    contrato.ExpedienteId = expediente.Id;
                    contrato.ModalidadeContratoId = modalidadeContrato.Id;
                    contrato.DataInicio = inicioContrato;
                    contrato.DataFim = fimContrato;
                    this.context.Add(contrato);
                    return contrato;
                }

                return contrato;
            }

            Contrato nulo = null;
            return nulo;
        }
        public void AddRegistroPonto(DateTime data, string funcionarioId)
        {
            if (data != default(DateTime))
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
        }
    }
}