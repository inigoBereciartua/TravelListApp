using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelListApp_Backend.DTO_s;
using TravelListApp_Backend.Models;
using TravelListApp_Backend.Models.DAO;

namespace TravelListApp_Backend.Controllers
{
    [Route("api/[controller]")]
    public class ItemController : Controller
    {
        private readonly ITravelerRepository _travelerRepository;
        private readonly IItemRepository _itemRepository;
        private readonly UserManager<ApplicationUser> _userManager;

        public ItemController(ITravelerRepository userRepository, IItemRepository itemRepository, UserManager<ApplicationUser> userManager)
        {
            this._travelerRepository = userRepository;
            this._itemRepository = itemRepository;
            this._userManager = userManager;
        }
        //Get all the items for thee current user
        [HttpGet()]
        public async Task<List<ItemDTO>> GetItems()
        {

            //Check if the user is authenticated
            if (User.Identity.IsAuthenticated)
            {
                var useraccount = await this._userManager.FindByNameAsync(User.Identity.Name);
                Item[] items = this._itemRepository.GetItemsOnUserId(_travelerRepository.getTraveler(useraccount).Id).ToArray();
                List<ItemDTO> dto = new List<ItemDTO>();
                foreach (var item in items)
                {
                    dto.Add(new ItemDTO() { Id = item.Id, Name = item.Name });
                }
                Response.StatusCode = 200;
                return dto;
            }
            Response.StatusCode = 401;
            return null; 
        }
        //Create an item for the curent user
        [HttpPost()]
        public async Task<IActionResult> CreateItem(ItemDTO itemDTO)
        {
            //Check if the user is authenticated
            if (User.Identity.IsAuthenticated)
            {
                //Add item with current traveler
                var useraccount = await this._userManager.FindByNameAsync(User.Identity.Name);
                Traveler traveler = this._travelerRepository.getTraveler(useraccount);
                Item item = new Item(itemDTO.Name, traveler);
                this._itemRepository.AddItem(item);
                this._itemRepository.SaveChanges();
                return Ok();
            }
            return Unauthorized();
        }
        //Delete an item of the curent user 
        [HttpDelete("{itemId}")]
        public async Task<IActionResult> DeleteItem(int itemId)
        {
            //Check if the user is authenticated
            if (User.Identity.IsAuthenticated)
            {
                //Add item with current traveler
                var useraccount = await this._userManager.FindByNameAsync(User.Identity.Name);
                Traveler traveler = this._travelerRepository.getTraveler(useraccount);
                Item item = this._itemRepository.GetItemsOnUserId(traveler.Id).FirstOrDefault(e => e.Id == itemId);
                if(item != null)
                {
                    
                    this._itemRepository.RemoveItem(item);
                    this._itemRepository.SaveChanges();
                    return Ok();
                }

                return NotFound();
            
            }
            return Unauthorized();
        }
    }
}
