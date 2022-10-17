using BusinessLogic;
using DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using System.Net;

namespace _2Pamoka.NET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IJwtService _jwtService;
        public AuthController(IAuthService authService, IJwtService jwtService)
        {
            _authService = authService;
            _jwtService = jwtService;
        }
        [HttpPost("signup")]
        public async Task<ActionResult> SignUp(SignUpDto signupModel)
        {
            await _authService.SignupNewAccauntAsync(signupModel.Username, signupModel.Password); //pilnai laimei reikia validuotis ar toks egzistuoja ar ne. 
            return StatusCode((int)HttpStatusCode.Created);
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login(LoginDto loginModel)
        {
            var (loginSuccess, role) = await _authService.LoginAsync(loginModel.Username, loginModel.Password);
            if (!loginSuccess)
            {
                return BadRequest();
            }

            return Ok(_jwtService.GetJwtToken(loginModel.Username, role));
        }



        [HttpPut("changeRole")]
        [Authorize(Roles = "00Admin")]









        public IActionResult ChangeRole([FromQuery] int id, UpdateDto updateDto)
        {
            var updatedAccount = new Accaunt()
            {
            Id = id,
            Role=updateDto.role
            };
            _authService.SaveUpdated(updatedAccount.Id, updatedAccount.Role);
            return Ok(updatedAccount);
        }

    }
}
