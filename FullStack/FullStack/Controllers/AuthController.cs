using FullStack.Dtos;
using FullStackBL;
using FullStackDomain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FullStack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserAccountService _userAccountService;
        private readonly IJwtService _jwtService;
        public AuthController(IUserAccountService userAccountService, IJwtService jwtService)
        {
            _userAccountService = userAccountService;
            _jwtService = jwtService;
        }



        [HttpPost("Signup")] //rout'as
        public async Task<IActionResult> Signup(SignupDto signupDto)
        {
            var domainContactDetails = signupDto.ContactDetails.Select(c => new ContactDetail
            {
                ContactValue = c.ContactValue,
                Type = c.Type
            }).ToList();
            var success = await _userAccountService.CreateUserAccountAsync(signupDto.UserName, signupDto.Password, domainContactDetails);

            return success ? Ok() : BadRequest(new { ErrorMessage = "User already exist" });

        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        { 
        var (loginSuccess, account) = await _userAccountService.LoginAsync(loginDto.UserName, loginDto.Password);
            if (loginSuccess)
            {
                return Ok(new {Token= _jwtService.GetJwtToken(account) }); //jeigu all good priskiriam jwt tokena useriui
            }
            else
            {
                return BadRequest(new { ErrorMessage = "Login failed" });
            }
        }
       

}
    }

