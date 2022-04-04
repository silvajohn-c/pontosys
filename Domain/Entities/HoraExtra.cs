namespace pontosys.Domain.Entities
{
    public class HoraExtra
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public int Quantidade { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }
        public bool Ativo { get; set; } = true;
        public string FuncionarioId { get; set; }
        public string ModalidadeHoraExtraId { get; set; }
        public string PeriodoHoraExtraId { get; set; }

        public Funcionario Funcionario { get; set; }
        public ModalidadeHoraExtra ModalidadeHoraExtra { get; set; }
        public PeriodoHoraExtra PeriodoHoraExtra{ get; set; }
    }
}