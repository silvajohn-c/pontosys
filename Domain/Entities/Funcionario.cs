namespace pontosys.Domain.Entities
{
    public class Funcionario
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public long Cpf { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }
        public bool Ativo { get; set; } = true;

        public ICollection<Contrato> Contratos { get; set; }
        public ICollection<HoraExtra> HorasExtras { get; set; }
        public ICollection<Ocorrencia> Ocorrencias { get; set; }
        public ICollection<RegistroPonto> RegistrosPontos { get; set; }
    }
}