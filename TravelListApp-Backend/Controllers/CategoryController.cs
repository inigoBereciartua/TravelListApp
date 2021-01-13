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

/*
        //Create category for the connected user
        [HttpPost("{categoryName}")]
        public IActionResult CreateCategory(string categoryName)
        {
            try
            {
                Category category = new Category(categoryName, new List<Item>());
                this._categoryRepository.addItem(category);
                this._categoryRepository.SaveChanges();
                Ok(category);
            }
            catch (Exception)
            {
                Response.StatusCode = 500;
                return Json(new { status = "500", message = "Sorry there war an error on our servers please try later." });
            }

            return NoContent();
        }

        //Get all the categories for the connected user
        [HttpGet()]
        public IActionResult GetCategories()
        {
            try
            {
                Category category = new Category(categoryName, new List<Item>());
                this._categoryRepository.addItem(category);
                this._categoryRepository.SaveChanges();
                Ok(category);
            }
            catch (Exception)
            {
                Response.StatusCode = 500;
                return Json(new { status = "500", message = "Sorry there war an error on our servers please try later." });
            }

            return NoContent();
        }

        //Remove the category for the connected user
        [HttpDelete("{id}")]
        public IActionResult RemoveCategory(int id)
        {
            try
            {
                Category category = this._categoryRepository.getItem(id);
                if (category != null)
                {
                    this._categoryRepository.removeItem(category);
                    this._categoryRepository.SaveChanges();
                    Ok();
                }
                else
                {
                    NotFound(id);
                }
            }
            catch (Exception)
            {
                Response.StatusCode = 500;
                return Json(new { status="500",message="Sorry there war an error on our servers please try later." });
            }

            return NoContent();
        }

        //Add the item for the category for the connected user
        [HttpPut("{id}/item/{itemId}")]
        public IActionResult AddItem(int id, int itemId)
        {



            try
            {
                Category category = this._categoryRepository.getItem(id);
                if (category != null)
                {
                    Item item = this._itemRepository.getItem(itemId);

                    if(item != null)
                    {
                        category.addItem(item);
                        this._categoryRepository.SaveChanges();
                       return  Ok();
                    }
                    else
                    {
                        return NotFound(itemId);
                    }
                }
                else
                {
                    NotFound(id);
                }
            }
            catch (Exception)
            {
                Response.StatusCode = 500;
                return Json(new { status = "500", message = "Sorry there war an error on our servers please try later." });
            }

            return NoContent();
        }

        //Remove item from the category for the connected user
        [HttpDelete("{id}/item/{itemId}")]
        public IActionResult RemoveItem(int id, int itemId)
        {
            try
            {
                Category category = this._categoryRepository.getItem(id);
                if (category != null)
                {
                    Item item = this._itemRepository.getItem(itemId);

                    if (item != null)
                    {
                        category.addItem(item);
                        this._categoryRepository.SaveChanges();
                        Ok();
                    }
                    else
                    {
                        NotFound(itemId);
                    }
                }
                else
                {
                    NotFound(id);
                }
            }
            catch (Exception)
            {
                Response.StatusCode = 500;
                return Json(new { status = "500", message = "Sorry there war an error on our servers please try later." });
            }

            return NoContent();
        }
*/
        //Get the items for the category for the current user
        [HttpGet("{id}/item")]
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
                                dto.Add(new ItemDTO() { id = item.Id, name = item.Name });
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

    }
}
