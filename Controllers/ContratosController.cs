using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CrudApp.Data;
using CrudApp.Models;

namespace CrudApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContratosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ContratosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Contratos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Contrato>>> GetContratos()
        {
            return await _context.Contratos
                .Include(c => c.Imovel)
                .Include(c => c.Cliente)
                .ToListAsync();
        }

        // GET: api/Contratos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Contrato>> GetContrato(int id)
        {
            var contrato = await _context.Contratos
                .Include(c => c.Imovel)
                .Include(c => c.Cliente)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (contrato == null)
            {
                return NotFound();
            }

            return contrato;
        }

        // GET: api/Contratos/ativos
        [HttpGet("ativos")]
        public async Task<ActionResult<IEnumerable<Contrato>>> GetContratosAtivos()
        {
            return await _context.Contratos
                .Include(c => c.Imovel)
                .Include(c => c.Cliente)
                .Where(c => c.Status == "Ativo")
                .ToListAsync();
        }

        // POST: api/Contratos
        [HttpPost]
        public async Task<ActionResult<Contrato>> PostContrato(Contrato contrato)
        {
            // Verificar se o imóvel existe
            var imovel = await _context.Imoveis.FindAsync(contrato.ImovelId);
            if (imovel == null)
            {
                return BadRequest(new { message = "Imóvel não encontrado." });
            }

            // Verificar se já existe contrato ativo para este imóvel
            var contratoExistente = await _context.Contratos
                .AnyAsync(c => c.ImovelId == contrato.ImovelId && c.Status == "Ativo");

            if (contratoExistente)
            {
                return BadRequest(new { message = "Já existe um contrato ativo para este imóvel." });
            }

            // Atualizar status do imóvel
            imovel.Status = "Ocupado";
            _context.Entry(imovel).State = EntityState.Modified;

            _context.Contratos.Add(contrato);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetContrato), new { id = contrato.Id }, contrato);
        }

        // PUT: api/Contratos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContrato(int id, Contrato contrato)
        {
            if (id != contrato.Id)
            {
                return BadRequest();
            }

            _context.Entry(contrato).State = EntityState.Modified;

            // Se o contrato foi encerrado, liberar o imóvel
            if (contrato.Status == "Encerrado" || contrato.Status == "Cancelado")
            {
                var imovel = await _context.Imoveis.FindAsync(contrato.ImovelId);
                if (imovel != null)
                {
                    imovel.Status = "Disponivel";
                    _context.Entry(imovel).State = EntityState.Modified;
                }
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContratoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/Contratos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContrato(int id)
        {
            var contrato = await _context.Contratos.FindAsync(id);
            if (contrato == null)
            {
                return NotFound();
            }

            // Liberar o imóvel
            var imovel = await _context.Imoveis.FindAsync(contrato.ImovelId);
            if (imovel != null)
            {
                imovel.Status = "Disponivel";
                _context.Entry(imovel).State = EntityState.Modified;
            }

            _context.Contratos.Remove(contrato);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ContratoExists(int id)
        {
            return _context.Contratos.Any(e => e.Id == id);
        }
    }
}
