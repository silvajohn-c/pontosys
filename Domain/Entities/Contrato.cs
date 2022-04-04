namespace pontosys.Domain.Entities
{
    public class Contrato
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public string FuncionarioId { get; set; }
        public string ModalidadeContratoId { get; set; }
        public string ExpedienteId { get; set; }
        public string CargoId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }

        public Cargo Cargo { get; set; }
        public Expediente Expediente { get; set; }
        public Funcionario Funcionario { get; set; }
        public ModalidadeContrato ModalidadeContrato { get; set; }
    }
}