namespace pontosys.Domain.Models
{
    public class CsvModel
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public long Cpf { get; set; }
        public string Cargo { get; set; }
        public int CargaHoraria { get; set; }
        public string ModalidadeContrato { get; set; }
        public DateTime InicioContrato { get; set; }
    }
}