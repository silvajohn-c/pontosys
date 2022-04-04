namespace pontosys.Domain.Entities
{
    public class StatusOcorrencia
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }
        public bool Ativo { get; set; } = true;

        public ICollection<Ocorrencia> Ocorrencias { get; set; }
    }
}