using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using pamoka11JWT.Dto;
using pamoka11JWT.Services;
using System.Net;

namespace pamoka11JWT.Controllers
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

    }
}
