namespace FUCT.Transportes.API.Models
{
    public class Transporte
    {
        public int Id { get; set; }
        public DateTime DataSaida { get; set; }
        public DateTime? DataRetorno { get; set; }
        public int CargueiroId { get; set; }
        public Cargueiro Cargueiro { get; set; }
        public int MinérioId { get; set; }
        public Minério Minério { get; set; }
        public double QuantidadeTransportada { get; set; }
    }
}
