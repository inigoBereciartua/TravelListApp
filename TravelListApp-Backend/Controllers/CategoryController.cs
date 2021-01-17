using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelListApp_Backend.Models;
using TravelListApp_Backend.Models.DAO;
using TravelListApp_Backend.DTO_s;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace TravelListApp_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : Controller
    {
        private readonly ITravelerRepository _userRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IItemRepository _itemRepository;
        private readonly UserManager<ApplicationUser> _userManager;

        public CategoryController(ICategoryRepository categoryRepository, ITravelerRepository userRepository, IItemRepository itemRepository, UserManager<ApplicationUser> userManager)
        {
            this._categoryRepository = categoryRepository;
            this._userRepository = userRepository;
            this._itemRepository = itemRepository;
            this._userManager = userManager;
        }

        //Create category for the connected user
        [HttpPost("{categoryName}")]
        public async Task<IActionResult> CreateCategory(CategoryDTO categoryDTO)
        {
            //Check if the user is authenticated
            if (User.Identity.IsAuthenticated)
            {
                //Add categeory to current traveler
                var useraccount = await this._userManager.FindByNameAsync(User.Identity.Name);
                Traveler traveler = this._userRepository.getTraveler(useraccount);
                Category category = new Category(categoryDTO.Name);
                traveler.Categories.Add(category);
                this._userRepository.SaveChanges();
                return Ok();
            }
            return Unauthorized();
        }

        //Get all the categories for the connected user
        [HttpGet()]
        public async Task<List<CategoryDTO>> GetCategories()
        {

            //Check if the user is authenticated
            if (User.Identity.IsAuthenticated)
            {
                var useraccount = await this._userManager.FindByNameAsync(User.Identity.Name);
                List<Category> categories = this._userRepository.getTraveler(useraccount).Categories;
                List<CategoryDTO> dto = new List<CategoryDTO>();
                foreach (var item in categories.ToArray())
                {
                    dto.Add(new CategoryDTO() { Id = item.Id, Name = item.Name });
                }
                Response.StatusCode = 200;
                return dto;
            }
            Response.StatusCode = 401;
            return null; ;
        }

        //Get the items for the category for the current user
        [HttpGet("{id}/Items")]
        public async Task<List<ItemDTO>> GetCategoryItems(int id)
        {
            if (User.Identity.IsAuthenticated)
            {
                //Get user account 
                var useraccount = await this._userManager.FindByNameAsync(User.Identity.Name);
                Category category = this._categoryRepository.getItem(id);

                //Check if this user has the specified category     
                if (category != null && this._userRepository.getTraveler(useraccount).Categories.Contains(category))
                {
                    List<Item> items = this._categoryRepository.getItem(id).Items;

                    if (items != null)
                    {
                        List<ItemDTO> dto = new List<ItemDTO>();
                        foreach (var item in items)
                        {
                            dto.Add(new ItemDTO() { Id = item.Id, Name = item.Name });
                        }
                        Response.StatusCode = 200;
                        return dto;
                    }
                }
                Response.StatusCode = 204;
                return null;
            }

            Response.StatusCode = 401;
            return null;
        }

        //Add the item for the category for the connected user
        [HttpPut("Item")]
        public async Task<IActionResult> AddItem(CategoryItem categoryItem)
        {
            //Check if the user is authenticated
            if (User.Identity.IsAuthenticated)
            {
                var useraccount = await this._userManager.FindByNameAsync(User.Identity.Name);
                Traveler traveler = this._userRepository.getTraveler(useraccount);
                Category category = traveler.Categories.FirstOrDefault(e => e.Id == categoryItem.CategorylId);
                if (category != null)
                {
                    Item item = this._itemRepository.GetItem(categoryItem.ItemId);
                    if(item != null)
                    {
                        category.Items.Add(item);
                        this._categoryRepository.SaveChanges();
                        return Ok();
                    }
                }
                return NotFound();
            }
            return Unauthorized();
        }

        //Remove item from the category for the connected user
        [HttpDelete("{id}/item/{itemId}")]
        public async Task<IActionResult> RemoveItem(int id, int itemId)
        {
            //Check if the user is authenticated
            if (User.Identity.IsAuthenticated)
            {
                var useraccount = await this._userManager.FindByNameAsync(User.Identity.Name);
                Traveler traveler = this._userRepository.getTraveler(useraccount);
                Category category = traveler.Categories.FirstOrDefault(e => e.Id == id);
                if (category != null)
                {
                    Item item = category.Items.FirstOrDefault(e => e.Id == itemId);
                    if (item != null)
                    {
                        category.Items.Remove(item);
                        this._categoryRepository.SaveChanges();
                        return Ok();
                    }
                }
                return NotFound();
            }
            return Unauthorized();
        }

        //Remove the category for the connected user
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveCategory(int id)
        {
            //Check if the user is authenticated
            if (User.Identity.IsAuthenticated)
            {
                var useraccount = await this._userManager.FindByNameAsync(User.Identity.Name);
                Traveler traveler = this._userRepository.getTraveler(useraccount);
                Category category = traveler.Categories.FirstOrDefault(e => e.Id == id);
                if (category != null)
                {
                    traveler.Categories.Remove(category);
                    this._categoryRepository.removeItem(category);
                    this._categoryRepository.SaveChanges();
                    return Ok();
                }
                return NotFound();
            }
            return Unauthorized();
        }

       

    }
}
