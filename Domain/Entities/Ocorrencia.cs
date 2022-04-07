namespace pontosys.Domain.Entities
{
    public class Ocorrencia
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Descricao { get; set; }
        public string StatusOcorrenciaId { get; set; }
        public string TipoOcorrenciaId { get; set; }
        public string FuncionarioId { get; set; }
        public DateTime Data { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }
        public bool Ativo { get; set; } = true;

        public Funcionario Funcionario { get; set; }
        public StatusOcorrencia StatusOcorrencia { get; set; }
        public TipoOcorrencia TipoOcorrencia { get; set; }
    }
}