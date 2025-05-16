namespace FUCT.Transportes.API.Models
{
    public class Cargueiro
    {
        public int Id { get; set; }
        public string Classe { get; set; }
        public double Capacidade { get; set; }
        public string TipoMinérioCompatível { get; set; }
    }
}

