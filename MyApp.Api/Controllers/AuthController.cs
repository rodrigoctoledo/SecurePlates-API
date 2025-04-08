using Microsoft.AspNetCore.Mvc;
using MyApp.Application.Services;
using MyApp.Domain.Entities;
using MyApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace MyApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IAuthService _authService;

        public AuthController(ApplicationDbContext context, IAuthService authService)
        {
            _context = context;
            _authService = authService;
        }

        // Endpoint para registro de usuário
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserRegisterDto dto)
        {
            if (await _context.Users.AnyAsync(u => u.Email == dto.Email))
            {
                return BadRequest("Email já está em uso.");
            }

            var user = new User
            {
                Nome = dto.Nome,
                Email = dto.Email,
                NiveisUsuario = dto.NiveisUsuario,
                SenhaHash = _authService.HashPassword(dto.Senha)
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return Ok("Usuário registrado com sucesso.");
        }

        // Endpoint para login
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDto dto)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == dto.Email);
            if (user == null)
            {
                return Unauthorized("Usuário não encontrado.");
            }

            if (!_authService.VerifyPassword(user.SenhaHash, dto.Senha))
            {
                return Unauthorized("Senha inválida.");
            }

            var token = _authService.GenerateToken(user);
            return Ok(new { Token = token, user.Id });
        }

        // Endpoint para recuperação de senha
        [HttpPost("recover")]
        public async Task<IActionResult> RecoverPassword([FromBody] PasswordRecoveryDto dto)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == dto.Email);
            if (user == null)
            {
                return NotFound("Usuário não encontrado.");
            }

            // Em um cenário real, enviaríamos um e-mail com link para redefinição.
            user.SenhaHash = _authService.HashPassword(dto.NovaSenha);
            _context.Users.Update(user);
            await _context.SaveChangesAsync();

            return Ok("Senha atualizada com sucesso.");
        }
    }

    // DTOs usados neste controlador
    public class UserRegisterDto
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string NiveisUsuario { get; set; }
    }

    public class UserLoginDto
    {
        public string Email { get; set; }
        public string Senha { get; set; }
    }

    public class PasswordRecoveryDto
    {
        public string Email { get; set; }
        public string NovaSenha { get; set; }
    }
}
