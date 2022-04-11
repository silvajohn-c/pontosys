namespace pontosys.Domain.Models
{
    public class XlsModel
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public long Cpf { get; set; }
        public string Cargo { get; set; }
        public int CargaHoraria { get; set; }
        public string ModalidadeContrato { get; set; }
        public DateTime InicioContrato { get; set; }
        public DateTime FimContrato { get; set; }
        public string Ocorrencia { get; set; }
        public DateTime DataOcorrencia { get; set; }
        public string TipoOcorrencia { get; set; }
        public string StatusOcorrencia { get; set; }
        public DateTime RegistroPonto { get; set; }
        public int HoraExtra { get; set; }
        public DateTime DataHoraExtra { get; set; }
        public float ModalidadeHoraExtra { get; set; }
        public string PeriodoHoraExtra { get; set; }
    }
}
