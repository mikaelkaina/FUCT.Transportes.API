using FUCT.Transportes.API.Data;
using FUCT.Transportes.API.Models;
using Microsoft.EntityFrameworkCore;

namespace FUCT.Transportes.API.Services
{
    public class DataSeeder
    {
        private readonly TransportesContext _context;
        private readonly Random _random = new();

        public DataSeeder(TransportesContext context)
        {
            _context = context;
        }

        public async Task SeedDataAsync()
        {
            if (await _context.Transportes.AnyAsync()) return; 

            var cargueiros = await _context.Cargueiros.ToListAsync();
            var minerios = await _context.Minerios.ToListAsync();

            DateTime dataInicio = DateTime.UtcNow.AddYears(-1);
            DateTime dataAtual = DateTime.UtcNow;

            var transportes = new List<Transporte>();

            while (dataInicio <= dataAtual)
            {
                if (dataInicio.DayOfWeek != DayOfWeek.Sunday)
                {
                    var cargueiro = cargueiros[_random.Next(cargueiros.Count)];
                    var minerio = DefinirMinérioPrioritario(minerios, cargueiro);

                    transportes.Add(new Transporte
                    {
                        DataSaida = new DateTime(dataInicio.Year, dataInicio.Month, dataInicio.Day, 8, 0, 0),
                        DataRetorno = dataInicio.AddDays(_random.Next(1, 7)),
                        CargueiroId = cargueiro.Id,
                        MinérioId = minerio.Id,
                        QuantidadeTransportada = cargueiro.Capacidade
                    });
                }

                
                dataInicio = dataInicio.AddDays(1);
            }

            _context.Transportes.AddRange(transportes);
            await _context.SaveChangesAsync();
        }

        private Minério DefinirMinérioPrioritario(List<Minério> minerios, Cargueiro cargueiro)
        {
            var tiposCompativeis = minerios.Where(m => cargueiro.TipoMinérioCompatível.Contains(m.Nome)).ToList();
            return tiposCompativeis.OrderByDescending(m => m.PrecoPorKg).FirstOrDefault() ?? tiposCompativeis.First();
        }
    }
}
