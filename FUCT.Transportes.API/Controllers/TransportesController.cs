using Microsoft.AspNetCore.Mvc;
using FUCT.Transportes.API.Data;
using FUCT.Transportes.API.Models;
using Microsoft.EntityFrameworkCore;
using FUCT.Transportes.API.DTOs;

namespace FUCT.Transportes.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransportesController : ControllerBase
    {
        private readonly TransportesContext _context;

        public TransportesController(TransportesContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetTransportes()
        {
            var transportes = await _context.Transportes.ToListAsync();
            return Ok(transportes);
        }

        [HttpPost]
        public async Task<IActionResult> AdicionarTransporte(TransporteDTO transporteDto)
        {
            var transporte = new Transporte
            {
                DataSaida = transporteDto.DataSaida,
                DataRetorno = transporteDto.DataRetorno,
                CargueiroId = transporteDto.CargueiroId,
                MinérioId = transporteDto.MinerioId,
                QuantidadeTransportada = transporteDto.QuantidadeTransportada
            };

            _context.Transportes.Add(transporte);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetTransportes), new { id = transporte.Id }, transporte);
        }
    }
}