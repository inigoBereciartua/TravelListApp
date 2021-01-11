using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using TravelListApp_Backend.Models.DAO;

namespace TravelListApp_Backend.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }

        [HttpPost("login")]
        public IActionResult login()
        {
            return Ok();
        }

        [HttpPost("register")]
        public IActionResult register()
        {
            return Ok();
        }


        [HttpGet("update")]
        public IActionResult update()
        {
            return Ok();
        }

        [HttpGet("delete")]
        public IActionResult delete()
        {
            return Ok();
        }

    }
}
