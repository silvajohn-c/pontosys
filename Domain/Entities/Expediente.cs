namespace pontosys.Domain.Entities
{
    public class Expediente
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public int CargaHoraria { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }
        public bool Ativo { get; set; } = true;

        public ICollection<Contrato> Contratos { get; set; }
    }
}