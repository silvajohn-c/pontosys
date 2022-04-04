namespace pontosys.Domain.Entities
{
    public class TipoOcorrencia
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Descricao { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }
        public bool Ativo { get; set; } = true;

        public ICollection<Ocorrencia> Ocorrencias { get; set; }
    }
}