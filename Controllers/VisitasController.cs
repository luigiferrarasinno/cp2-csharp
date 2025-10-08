using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CrudApp.Data;
using CrudApp.Models;

namespace CrudApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisitasController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public VisitasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Visitas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Visita>>> GetVisitas()
        {
            return await _context.Visitas
                .Include(v => v.Imovel)
                .Include(v => v.Cliente)
                .OrderBy(v => v.DataVisita)
                .ThenBy(v => v.HoraInicio)
                .ToListAsync();
        }

        // GET: api/Visitas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Visita>> GetVisita(int id)
        {
            var visita = await _context.Visitas
                .Include(v => v.Imovel)
                .Include(v => v.Cliente)
                .FirstOrDefaultAsync(v => v.Id == id);

            if (visita == null)
            {
                return NotFound();
            }

            return visita;
        }

        // GET: api/Visitas/agendadas
        [HttpGet("agendadas")]
        public async Task<ActionResult<IEnumerable<Visita>>> GetVisitasAgendadas()
        {
            var hoje = DateTime.Today;
            return await _context.Visitas
                .Include(v => v.Imovel)
                .Include(v => v.Cliente)
                .Where(v => v.DataVisita >= hoje && (v.Status == "Agendada" || v.Status == "Confirmada"))
                .OrderBy(v => v.DataVisita)
                .ThenBy(v => v.HoraInicio)
                .ToListAsync();
        }

        // POST: api/Visitas
        [HttpPost]
        public async Task<ActionResult<Visita>> PostVisita(Visita visita)
        {
            // Verificar se o imóvel existe
            var imovel = await _context.Imoveis.FindAsync(visita.ImovelId);
            if (imovel == null)
            {
                return BadRequest(new { message = "Imóvel não encontrado." });
            }

            // REGRA: Não permitir sobreposição de visitas
            var visitaSobreposta = await _context.Visitas
                .AnyAsync(v => 
                    v.ImovelId == visita.ImovelId &&
                    v.DataVisita.Date == visita.DataVisita.Date &&
                    v.Status != "Cancelada" &&
                    (
                        // Nova visita começa durante uma visita existente
                        (visita.HoraInicio >= v.HoraInicio && visita.HoraInicio < v.HoraFim) ||
                        // Nova visita termina durante uma visita existente
                        (visita.HoraFim > v.HoraInicio && visita.HoraFim <= v.HoraFim) ||
                        // Nova visita engloba uma visita existente
                        (visita.HoraInicio <= v.HoraInicio && visita.HoraFim >= v.HoraFim)
                    )
                );

            if (visitaSobreposta)
            {
                return BadRequest(new { message = "Já existe uma visita agendada para este imóvel no horário solicitado." });
            }

            // Validar horários
            if (visita.HoraInicio >= visita.HoraFim)
            {
                return BadRequest(new { message = "A hora de início deve ser anterior à hora de término." });
            }

            _context.Visitas.Add(visita);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetVisita), new { id = visita.Id }, visita);
        }

        // PUT: api/Visitas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVisita(int id, Visita visita)
        {
            if (id != visita.Id)
            {
                return BadRequest();
            }

            // Verificar sobreposição ao editar (excluindo a própria visita)
            var visitaSobreposta = await _context.Visitas
                .AnyAsync(v => 
                    v.Id != id &&
                    v.ImovelId == visita.ImovelId &&
                    v.DataVisita.Date == visita.DataVisita.Date &&
                    v.Status != "Cancelada" &&
                    (
                        (visita.HoraInicio >= v.HoraInicio && visita.HoraInicio < v.HoraFim) ||
                        (visita.HoraFim > v.HoraInicio && visita.HoraFim <= v.HoraFim) ||
                        (visita.HoraInicio <= v.HoraInicio && visita.HoraFim >= v.HoraFim)
                    )
                );

            if (visitaSobreposta)
            {
                return BadRequest(new { message = "Já existe uma visita agendada para este imóvel no horário solicitado." });
            }

            _context.Entry(visita).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VisitaExists(id))
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

        // DELETE: api/Visitas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVisita(int id)
        {
            var visita = await _context.Visitas.FindAsync(id);
            if (visita == null)
            {
                return NotFound();
            }

            _context.Visitas.Remove(visita);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VisitaExists(int id)
        {
            return _context.Visitas.Any(e => e.Id == id);
        }
    }
}
