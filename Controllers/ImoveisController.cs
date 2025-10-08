using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CrudApp.Data;
using CrudApp.Models;

namespace CrudApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImoveisController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ImoveisController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Imoveis
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Imovel>>> GetImoveis()
        {
            return await _context.Imoveis.ToListAsync();
        }

        // GET: api/Imoveis/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Imovel>> GetImovel(int id)
        {
            var imovel = await _context.Imoveis.FindAsync(id);

            if (imovel == null)
            {
                return NotFound();
            }

            return imovel;
        }

        // GET: api/Imoveis/disponiveis
        [HttpGet("disponiveis")]
        public async Task<ActionResult<IEnumerable<Imovel>>> GetImoveisDisponiveis()
        {
            return await _context.Imoveis
                .Where(i => i.Status == "Disponivel" && i.Ativo)
                .ToListAsync();
        }

        // POST: api/Imoveis
        [HttpPost]
        public async Task<ActionResult<Imovel>> PostImovel(Imovel imovel)
        {
            _context.Imoveis.Add(imovel);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetImovel), new { id = imovel.Id }, imovel);
        }

        // PUT: api/Imoveis/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutImovel(int id, Imovel imovel)
        {
            if (id != imovel.Id)
            {
                return BadRequest();
            }

            // Verificar se existe contrato ativo para este imóvel
            var contratoAtivo = await _context.Contratos
                .AnyAsync(c => c.ImovelId == id && c.Status == "Ativo");

            if (contratoAtivo)
            {
                // Bloquear alterações em campos críticos se houver contrato ativo
                var imovelOriginal = await _context.Imoveis.AsNoTracking().FirstOrDefaultAsync(i => i.Id == id);
                
                if (imovelOriginal != null)
                {
                    // Permitir apenas alteração de Status e Observações
                    imovel.Titulo = imovelOriginal.Titulo;
                    imovel.Descricao = imovelOriginal.Descricao;
                    imovel.TipoImovel = imovelOriginal.TipoImovel;
                    imovel.Finalidade = imovelOriginal.Finalidade;
                    imovel.ValorVenda = imovelOriginal.ValorVenda;
                    imovel.ValorLocacao = imovelOriginal.ValorLocacao;
                    imovel.Endereco = imovelOriginal.Endereco;
                }
            }

            _context.Entry(imovel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ImovelExists(id))
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

        // DELETE: api/Imoveis/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteImovel(int id)
        {
            // Verificar se existe contrato ativo
            var contratoAtivo = await _context.Contratos
                .AnyAsync(c => c.ImovelId == id && c.Status == "Ativo");

            if (contratoAtivo)
            {
                return BadRequest(new { message = "Não é possível excluir imóvel com contrato ativo." });
            }

            var imovel = await _context.Imoveis.FindAsync(id);
            if (imovel == null)
            {
                return NotFound();
            }

            _context.Imoveis.Remove(imovel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ImovelExists(int id)
        {
            return _context.Imoveis.Any(e => e.Id == id);
        }
    }
}
