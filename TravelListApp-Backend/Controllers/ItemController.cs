using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelListApp_Backend.Controllers
{
    [Route("api/[controller]")]
    public class ItemController : Controller
    {
        [HttpGet("items")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
