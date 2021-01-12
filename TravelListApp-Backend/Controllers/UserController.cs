using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using TravelListApp_Backend.DTO_s;
using TravelListApp_Backend.Models;
using TravelListApp_Backend.Models.DAO;

namespace TravelListApp_Backend.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly ITravelerRepository _travelerRepository;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public UserController(ITravelerRepository userRepository, UserManager<ApplicationUser> userManager,SignInManager<ApplicationUser> signInManager)
        {
            this._travelerRepository = userRepository;
            this._userManager = userManager;
            this._signInManager = signInManager;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDTO dto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await this._signInManager.PasswordSignInAsync(dto.username, dto.password, false, false);

                    if (result.Succeeded)
                    {
                        Ok();
                    }
                    else
                    {
                        Unauthorized();
                    }
                }
            }
            catch (Exception)
            {
                return NoContent();
            }
            return NoContent();
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDTO dto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ApplicationUser user = new ApplicationUser() { Email = dto.email, UserName = dto.username };
                    var result = await this._userManager.CreateAsync(user, dto.password);

                    if (result.Succeeded)
                    {
                        Traveler traveler = new Traveler(user);
                        this._travelerRepository.addItem(traveler);
                        this._travelerRepository.SaveChanges();
                        await this._signInManager.SignInAsync(user, isPersistent: false);
                        Ok();
                    }
                }
            }
            catch (Exception)
            {
                return NoContent();
            }
            return NoContent();
        }


        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            return NoContent();
        }

    }
}
