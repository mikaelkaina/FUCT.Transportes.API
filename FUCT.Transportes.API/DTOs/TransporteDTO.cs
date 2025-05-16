namespace FUCT.Transportes.API.DTOs
{
    public class TransporteDTO
    {
        public DateTime DataSaida { get; set; }
        public DateTime? DataRetorno { get; set; }
        public int CargueiroId { get; set; }
        public int MinerioId { get; set; }
        public double QuantidadeTransportada { get; set; }
    }
}
