using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelListApp_Backend.Models;
using TravelListApp_Backend.Models.DAO;
using TravelListApp_Backend.DTO_s;

namespace TravelListApp_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IItemRepository _itemRepository;

        public CategoryController(ICategoryRepository categoryRepository, IUserRepository userRepository, IItemRepository itemRepository)
        {
            this._categoryRepository = categoryRepository;
            this._userRepository = userRepository;
            this._itemRepository = itemRepository;
        }


        [HttpGet("{id}")]
        public IActionResult Category(int id)
        {
            try
            {
                Category category = this._categoryRepository.getItem(id);
                if (category != null)
                {
                    Ok(category);
                }
                else
                {
                    return NotFound(id);
                }
            }
            catch (Exception)
            {
                return new JsonResult(new { status = "500", message = "Sorry we had an internal error pls try later." });
            }

            return NoContent();
        }

        [HttpPost("{categoryName}")]
        public IActionResult addCategory(string categoryName)
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

        [HttpDelete("{id}")]
        public IActionResult removeCategory(int id)
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

        [HttpPut("{id}/item/{itemId}")]
        public IActionResult addItem(int id, int itemId)
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

        [HttpPut()]
        public IActionResult updateCategory(CategoryDTO categoryDTO)
        {
            try
            {
                Category category = this._categoryRepository.getItem(categoryDTO.id);
                if (category != null)
                {
                    category.Name = categoryDTO.name;
                    this._categoryRepository.SaveChanges();
                    Ok(category);
                }
                else
                {
                    return NotFound(categoryDTO.id);
                }
            }
            catch (Exception)
            {
                return new JsonResult(new { status = "500", message = "Sorry we had an internal error pls try later." });
            }

            return NoContent();
        }
    }
}
