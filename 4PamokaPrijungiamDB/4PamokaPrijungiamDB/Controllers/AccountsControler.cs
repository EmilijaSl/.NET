using _4PamokaPrijungiamDB.NewFolder;
using BusinessLogic;
using Microsoft.AspNetCore.Mvc;
using Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace _4PamokaPrijungiamDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsControler : ControllerBase
    {
        private readonly IAccountService _service;
        private readonly ILogger<AccountsControler> _logger;
        public AccountsControler(IAccountService service, ILogger<AccountsControler> logger)
        {
            _service = service;
            _logger = logger;
        }

        // GET: api/<AccountsControler>
        [HttpGet]
        public IEnumerable<Account> Get()
        {
            _logger.LogDebug("Debug log");
            _logger.LogInformation("InformationLog");
            _logger.LogWarning("Warning log");
            _logger.LogError("Error log");
            _logger.LogCritical("Critical log");

            return _service.GetAllAccounts();
        }

        // GET api/<AccountsControler>/5
        [HttpGet("{id}")]
        public ActionResult GetAccountById(int id)
        {
            var account = _service.GetAccountById(id);
            return Ok(account);
        }

        // POST api/<AccountsControler>
        [HttpPost]
        public object Post([FromBody] AccountDto account)
        {
            _logger.LogInformation("api/Accounts [POST] action was called");
            var accountId = _service.AddAccount(new Account()
            {
                Balance = account.Balance,
                CreatedTime = account.CreatedTime,
                Owner = account.Owner,
                UpdateTime = account.UpdateTime,
            });
            _logger.LogInformation("Account was created with id");
            dynamic returnValue = new { Id = accountId };
            return returnValue;
        }

        // PUT api/<AccountsControler>/5
        [HttpPut]
        public IActionResult UpdateAccount(AccountDto accountDto, [FromQuery] int id)
        {
            var updatedAccount = new Account()
            {
                Id = id,
                Owner = accountDto.Owner,
                Balance = accountDto.Balance,
                CreatedTime = accountDto.CreatedTime,
                UpdateTime = accountDto.UpdateTime,
            };
            _service.UpdateAccount(updatedAccount);
            return Ok(updatedAccount);
        }

        // DELETE api/<AccountsControler>/5
        [HttpDelete]
        public object DeleteAccount(int id)
        {
            _service.DeleteAccount(id);
            return Ok();
        }
    }
}
