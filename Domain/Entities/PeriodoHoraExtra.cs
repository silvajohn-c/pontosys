namespace pontosys.Domain.Entities
{
    public class PeriodoHoraExtra
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Descricao { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }
        public bool Ativo { get; set; } = true;

        public ICollection<HoraExtra> HorasExtras { get; set; }
    }
}