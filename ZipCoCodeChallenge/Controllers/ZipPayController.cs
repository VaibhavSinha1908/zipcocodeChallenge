using Microsoft.AspNetCore.Mvc;
using ZipCoCodeChallenge.Interfaces;
using ZipCoCodeChallenge.Models;

namespace ZipCoCodeChallenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ZipPayController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IAccountService _accountService;

        public ZipPayController(IUserService userService, IAccountService accountService)
        {
            _userService = userService;
            _accountService = accountService;
        }

        // GET: api/ZipPay
        [HttpGet]
        public IActionResult ListUsers()
        {
            var model = _userService.GetAllUsers();
            return Ok(new { Users = model });
        }



        // GET: api/ZipPay/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult GetUser(int id)
        {
            var model = _userService.GetUser(id);
            return Ok(model);
        }

        // POST: api/ZipPay
        [HttpPost]
        public IActionResult Create([FromBody] UserDetails userDetails)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var response = _userService.AddUser(userDetails);

            return Ok(response);

        }


        [Route("accounts")]
        [HttpGet]
        public IActionResult GetAccounts()
        {
            var model = _accountService.GetAllAccounts();
            return Ok(model);
        }


        // [Route("accounts")]
        // [HttpPost]
        //public IActionResult CreateAccount([FromBody] UserDetails user)
        //{
        //    if (!ModelState.IsValid)
        //        return BadRequest(ModelState);

        //    var response = _accountService.CreateAccount(user);
        //    if (response == "user doesn't exist")
        //        return BadRequest(response);
        //    else if (response == "Can't create user account!")
        //        return BadRequest(response);
        //    return Ok(response);
        //}


        [Route("accounts")]
        [HttpPost]
        public IActionResult CreateAccount([FromBody]string email)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var response = _accountService.CreateAccount(email);
            if (response == "user doesn't exist")
                return BadRequest(response);
            else if (response == "Can't create user account!")
                return BadRequest(response);
            return Ok(response);
        }

    }
}
