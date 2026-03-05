using KariyerAgi.API.DTOs;
using KariyerAgi.DataAccess;
using KariyerAgi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KariyerAgi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        readonly private KariyerAgiContext _kariyerAgiContext;
        public UsersController(KariyerAgiContext kariyerAgiContext)
        {
            _kariyerAgiContext = kariyerAgiContext;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(User user)
        {
            var users = await _kariyerAgiContext.Users.AddAsync(user);
            await _kariyerAgiContext.SaveChangesAsync();
            return Ok();
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDto loginDto)
        {
            var user = await _kariyerAgiContext.Users.FirstOrDefaultAsync(u => u.Email == loginDto.Email && u.Password == loginDto.Password);
            if (user == null)
                return BadRequest("Kullanıcı Adı veya şifre hatalı");
            return Ok("Giriş Başarılı. Hoş geldin " + user.FirstName);
        }
    }
}
