namespace pontosys.Domain.Entities
{
    public class RegistroPonto
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }
        public string FuncionarioId { get; set; }
        public bool Ativo { get; set; } = true;

        public Funcionario Funcionario { get; set; }
    }
}