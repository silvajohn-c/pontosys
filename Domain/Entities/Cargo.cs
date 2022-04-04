namespace pontosys.Domain.Entities
{
    public class Cargo
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Nome { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }
        public bool Ativo { get; set; } = true;

        public ICollection<Contrato> Contratos { get; set; }
    }
}