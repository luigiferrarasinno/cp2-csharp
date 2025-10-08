using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CrudApp.Data;
using CrudApp.Models;

namespace CrudApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AuthController(ApplicationDbContext context)
        {
            _context = context;
        }

        // POST: api/Auth/Login
        [HttpPost("Login")]
        public async Task<ActionResult<LoginResponse>> Login([FromBody] LoginRequest request)
        {
            try
            {
                var usuario = await _context.Usuarios
                    .FirstOrDefaultAsync(u => u.Email == request.Email && u.Ativo);

                if (usuario == null)
                {
                    return Ok(new LoginResponse
                    {
                        Sucesso = false,
                        Mensagem = "Email ou senha incorretos"
                    });
                }

                if (usuario.Senha != request.Senha)
                {
                    return Ok(new LoginResponse
                    {
                        Sucesso = false,
                        Mensagem = "Email ou senha incorretos"
                    });
                }

                // Atualizar último acesso
                usuario.UltimoAcesso = DateTime.Now;
                await _context.SaveChangesAsync();

                // Não retornar a senha
                usuario.Senha = string.Empty;

                return Ok(new LoginResponse
                {
                    Sucesso = true,
                    Mensagem = "Login realizado com sucesso",
                    Usuario = usuario
                });
            }
            catch (Exception ex)
            {
                return Ok(new LoginResponse
                {
                    Sucesso = false,
                    Mensagem = "Erro ao realizar login: " + ex.Message
                });
            }
        }

        // POST: api/Auth/Logout
        [HttpPost("Logout")]
        public IActionResult Logout()
        {
            return Ok(new { sucesso = true, mensagem = "Logout realizado com sucesso" });
        }
    }
}
