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

        public Funcionario GetFuncionarioByCpf(long cpf)
        {
            return this.context.Funcionarios
                .FirstOrDefault(x => x.Cpf.Equals(cpf));
        }
        public Cargo GetCargoByName(string cargo)
        {
            return this.context.Cargos
                .FirstOrDefault(x => x.Nome == cargo);
        }

        public Expediente GetExpedienteByValue(int cargaHoraria)
        {
            return this.context.Expedientes
                .FirstOrDefault(x => x.CargaHoraria == cargaHoraria);
        }

        public ModalidadeContrato GetModalidadeContratoByName(string modalidadeContrato)
        {
            return this.context.ModalidadesContratos
                .FirstOrDefault(x => x.Nome == modalidadeContrato);
        }

        public Contrato GetContratoByForeignKeys(string funcionarioId, string cargoId, string expedienteId, string modalidadeContratoId, DateTime inicioContrato)
        {
            return this.context.Contratos
                .FirstOrDefault(x => x.FuncionarioId == funcionarioId && x.CargoId == cargoId && x.ExpedienteId == expedienteId && x.ModalidadeContratoId == modalidadeContratoId && x.DataInicio == inicioContrato);
        }

        public Ocorrencia GetOcorrenciaByDate(DateTime data, string funcionarioId)
        {
            return this.context.Ocorrencias
                .FirstOrDefault(x => x.Data == data && x.FuncionarioId == funcionarioId);
        }

        public TipoOcorrencia GetTipoOcorrenciaByDescricao(string descricao)
        {
            return this.context.TiposOcorrencias
                .FirstOrDefault(x => x.Descricao == descricao);
        }
        public StatusOcorrencia GetStatusOcorrenciaByName(string nome)
        {
            return this.context.StatusOcorrencias
                .FirstOrDefault(x => x.Nome == nome);
        }
        public RegistroPonto GetRegistroPontoDate(DateTime data)
        {
            return this.context.RegistrosPontos
                .FirstOrDefault(x => x.CreatedAt == data);
        }
        public HoraExtra GetHoraExtra(DateTime data, string funcionarioId)
        {
            return this.context.HorasExtras
                .FirstOrDefault(x => x.CreatedAt == data && x.FuncionarioId == funcionarioId);
        }
        public ModalidadeHoraExtra GetModalidadeHoraExtraByValue(float porcentagem)
        {
            return this.context.ModalidadesHorasExtras
                .FirstOrDefault(x => x.Valor == porcentagem);
        }
        public PeriodoHoraExtra GetPeriodoHoraExtraByDescricao(string descricao)
        {
            return this.context.PeriodosHorasExtras
                .FirstOrDefault(x => x.Descricao == descricao);
        }
    }
}