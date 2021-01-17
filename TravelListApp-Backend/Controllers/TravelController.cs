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
    public class TravelController : Controller
    {
        private readonly ITravelerRepository _travelerRepository;
        private readonly ITravelRepository _travelRepository;
        private readonly ITravelItemRepository _travelItemRepository;
        private readonly ITravelTaskRepository _travelTaskRepository;
        private readonly IItemRepository _itemRepository;
        private readonly IActivityRepository _activityRepository;
        private readonly UserManager<ApplicationUser> _userManager;

        public TravelController( IItemRepository itemRepository ,ITravelerRepository travelerRepository, ITravelRepository travelRepository ,ITravelItemRepository travelItemRepository, ITravelTaskRepository travelTaskRepository, IActivityRepository activityRepository ,UserManager<ApplicationUser> userManager)
        {
            this._activityRepository = activityRepository;
            this._itemRepository = itemRepository;
            this._travelerRepository = travelerRepository;
            this._travelRepository = travelRepository;
            this._travelItemRepository = travelItemRepository;
            this._travelTaskRepository = travelTaskRepository;
            this._userManager = userManager;
        }

        //Get all the travels of the current user
        [HttpGet()]
        public async Task<List<TravelDTO>> GetTravels()
        {

            //Check if the user is authenticated
            if (User.Identity.IsAuthenticated)
            {
                var useraccount = await this._userManager.FindByNameAsync(User.Identity.Name);
                Travel[] travels = this._travelerRepository.getTraveler(useraccount).Travels.ToArray();
                List<TravelDTO> dto = new List<TravelDTO>();
                foreach (var item in travels)
                {
                    dto.Add(new TravelDTO() { Id = item.Id, Name = item.Name , Start = item.Start, End = item.End});
                }
                Response.StatusCode = 200;
                return dto;
            }
            Response.StatusCode = 401;
            return null; ;
        }  
        //Get Travel category
        [HttpGet("{travelId}/Categories")]
        public async Task<List<CategoryDTO>> GetTravelCategories(int travelId)
        {
            //Check if the user is authenticated
            if (User.Identity.IsAuthenticated)
            {
                var useraccount = await this._userManager.FindByNameAsync(User.Identity.Name);
                Traveler traveler = this._travelerRepository.getTraveler(useraccount);
                Travel travel = traveler.Travels.FirstOrDefault(e => e.Id == travelId);
                if (travel != null)
                {
                    Category[] categories = travel.Categories.ToArray();
                    List<CategoryDTO> dto = new List<CategoryDTO>();
                    foreach (var item in categories)
                    {
                        dto.Add(new CategoryDTO() { Id = item.Id, Name = item.Name });
                    }
                    Response.StatusCode = 200;
                    return dto;
                }
                Response.StatusCode = 204;
                return null;
            }
            Response.StatusCode = 401;
            return null;
        }
        //Get Travel Task
        [HttpGet("{travelId}/Tasks")]
        public async Task<List<TaskDTO>> GetTravelTask(int travelId)
        {
            //Check if the user is authenticated
            if (User.Identity.IsAuthenticated)
            {
                var useraccount = await this._userManager.FindByNameAsync(User.Identity.Name);
                Traveler traveler = this._travelerRepository.getTraveler(useraccount);
                Travel travel = traveler.Travels.FirstOrDefault(e => e.Id == travelId);
                if (travel!=null)
                {
                    TravelTask[] travelTasks = this._travelTaskRepository.getTravelTaskOnTravelId(travel.Id).ToArray();
                    List<TaskDTO> dto = new List<TaskDTO>();
                    foreach (var item in travelTasks)
                    {
                        dto.Add(new TaskDTO() { Id = item.Id, Description = item.Task.Description, Checked = item.Checked });
                    }
                    Response.StatusCode = 200;
                    return dto;
                }
                Response.StatusCode = 204;
                return null;
            }
            Response.StatusCode = 401;
            return null;
        }
        //Get travel items 
        [HttpGet("{travelId}/Items")]
        public async Task<List<ItemDTO>> GetTravelItem(int travelId)
        {
            //Check if the user is authenticated
            if (User.Identity.IsAuthenticated)
            {
                var useraccount = await this._userManager.FindByNameAsync(User.Identity.Name);
                Traveler traveler = this._travelerRepository.getTraveler(useraccount);
                Travel travel = traveler.Travels.FirstOrDefault(e => e.Id == travelId);
                if (travel != null)
                {
                    TravelItem[] travelItem = this._travelItemRepository.getTravelItemOnTravelId(travel.Id).ToArray();
                    List<ItemDTO> dto = new List<ItemDTO>();
                    foreach (var item in travelItem)
                    {
                        dto.Add(new ItemDTO() { Id = item.Item.Id, Name = item.Item.Name , Checked = item.Checked, Count = item.Count});
                    }
                    Response.StatusCode = 200;
                    return dto;
                }
                Response.StatusCode = 204;
                return null;
            }
            Response.StatusCode = 401;
            return null;
        }
        //Get Activity
        [HttpGet("{travelId}/Activity")]
        public async Task<List<ActivityDTO>> GetTravelActivity(int travelId)
        {
            if (User.Identity.IsAuthenticated)
            {
                var useraccount = await this._userManager.FindByNameAsync(User.Identity.Name);
                Traveler traveler = this._travelerRepository.getTraveler(useraccount);
                Travel travel = traveler.Travels.FirstOrDefault(e => e.Id == travelId);
                if (travel != null)
                {
                    Activity[] items = travel.Iternary.ToArray();
                    List<ActivityDTO> dto = new List<ActivityDTO>();
                    foreach (var item in items)
                    {
                        dto.Add(new ActivityDTO() { Id = item.Id, Description = item.Description, Start = item.Start});
                    }
                    Response.StatusCode = 200;
                    return dto;
                }
            }
            Response.StatusCode = 401;
            return null;
        }
        //Create an Travel for the curent user
        [HttpPost()]
        public async Task<IActionResult> CreateTravel(TravelDTO travelDTO)
        {
            //Check if the user is authenticated
            if (User.Identity.IsAuthenticated)
            {
                if (ModelState.IsValid)
                {
                    //Add item with current traveler
                    var useraccount = await this._userManager.FindByNameAsync(User.Identity.Name);
                    Traveler traveler = this._travelerRepository.getTraveler(useraccount);
                    Travel travel = new Travel(travelDTO.Name) {Start = travelDTO.Start, End = travelDTO.End};
                    traveler.Travels.Add(travel);
                    this._travelerRepository.SaveChanges();
                    return Ok();
                }
                return NoContent();
            }
            return Unauthorized();
        }
        //Add a task for a travel
        [HttpPost("Task")]
        public async Task<IActionResult> AddTravelTask(TravelTaskDTO travelTaskDTO)
        {
            //Check if the user is authenticated
            if (User.Identity.IsAuthenticated)
            {
                var useraccount = await this._userManager.FindByNameAsync(User.Identity.Name);
                Traveler traveler = this._travelerRepository.getTraveler(useraccount);
                Travel travel = traveler.Travels.FirstOrDefault(e => e.Id == travelTaskDTO.TravelId);
                Models.Task task = traveler.Tasks.FirstOrDefault(e => e.Id == travelTaskDTO.TaskId);
                if (travel != null && task != null)
                {
                    TravelTask travelTask = new TravelTask(travel,task);
                    this._travelTaskRepository.addTravelTask(travelTask);
                    this._travelTaskRepository.SaveChanges();
                    return Ok();
                }
                return NoContent();
            }
            return Unauthorized();
        }
        //Add Activity
        [HttpPost("Activity")]
        public async Task<IActionResult> AddTravelActivity(ActivityDTO activityDTO)
        {
            //Check if the user is authenticated
            if (User.Identity.IsAuthenticated)
            {
                var useraccount = await this._userManager.FindByNameAsync(User.Identity.Name);
                Traveler traveler = this._travelerRepository.getTraveler(useraccount);
                Travel travel = traveler.Travels.FirstOrDefault(e => e.Id == activityDTO.TravelId);
                if (travel != null)
                {
                    Activity item = new Activity(activityDTO.Description, activityDTO.Start);
                    travel.Iternary.Add(item);
                    this._travelRepository.UpdateTravel(travel);
                    this._travelRepository.SaveChanges();
                }

                return Ok();
            }
            return Unauthorized();
        }
        //Add a item to a travel
        [HttpPost("Item")]
        public async Task<IActionResult> AddTravelItem(TravelItemDTO travelItemDTO)
        {
            //Check if the user is authenticated
            if (User.Identity.IsAuthenticated)
            {
                var useraccount = await this._userManager.FindByNameAsync(User.Identity.Name);
                Traveler traveler = this._travelerRepository.getTraveler(useraccount);
                Item item = this._itemRepository.GetItemsOnUserId(traveler.Id).FirstOrDefault(e => e.Id == travelItemDTO.ItemId);
                Travel travel = traveler.Travels.FirstOrDefault(e => e.Id == travelItemDTO.TravelId);
                if (travel != null && item != null)
                {
                    TravelItem travelItem = new TravelItem(travel, item, travelItemDTO.Count);
                    this._travelItemRepository.addTravelItem(travelItem);
                    this._travelItemRepository.SaveChanges();
                    return Ok();
                }
                return NoContent();
            }
            return Unauthorized();
        }
        //Add category to travel 
        [HttpPost("Category")]
        public async Task<IActionResult> AddTravelCategory(TravelCategory travelCategory)
        {
            //Check if the user is authenticated
            if (User.Identity.IsAuthenticated)
            {
                var useraccount = await this._userManager.FindByNameAsync(User.Identity.Name);
                Traveler traveler = this._travelerRepository.getTraveler(useraccount);
                Category category = traveler.Categories.FirstOrDefault(e => e.Id == travelCategory.CategoryId);
                Travel travel = traveler.Travels.FirstOrDefault(e => e.Id == travelCategory.TravelId);
                if (travel != null && category != null)
                {
                    travel.Categories.Add(category);
                    this._travelRepository.UpdateTravel(travel);
                    this._travelRepository.SaveChanges();
                    return Ok();
                }
                return NoContent();
            }
            return Unauthorized();
        }
        //Check a task for a travel
        [HttpPut("Task")]
        public async Task<IActionResult> CheckTravelTask(CheckTaskDTO checkTask)
        {
            //Check if the user is authenticated
            if (User.Identity.IsAuthenticated)
            {
                var useraccount = await this._userManager.FindByNameAsync(User.Identity.Name);
                Traveler traveler = this._travelerRepository.getTraveler(useraccount);
                Models.Task task = traveler.Tasks.FirstOrDefault(e => e.Id == checkTask.TaskId);
                Travel travel = traveler.Travels.FirstOrDefault(e => e.Id == checkTask.TravelId);
                if (travel != null && task != null)
                {
                    TravelTask travelTask = this._travelTaskRepository.getTravelTaskOnTravelId(checkTask.TravelId).FirstOrDefault(e => e.Task.Id == checkTask.TaskId);
                    if(travelTask != null) {
                        travelTask.Checked = checkTask.Completed;
                        this._travelTaskRepository.updateTravelTask(travelTask);
                        this._travelTaskRepository.SaveChanges();
                        return Ok();
                    }
                    return NoContent();
                }
                return NoContent();
            }
            return Unauthorized();
        }
        //Check a item for a travel
        [HttpPut("Item")]
        public async Task<IActionResult> CheckTravelItem(CheckItemDTO checkItem)
        {
            //Check if the user is authenticated
            if (User.Identity.IsAuthenticated)
            {
                var useraccount = await this._userManager.FindByNameAsync(User.Identity.Name);
                Traveler traveler = this._travelerRepository.getTraveler(useraccount);
                Travel travel = traveler.Travels.FirstOrDefault(e => e.Id == checkItem.TravelId);
                if (travel != null)
                {
                    TravelItem travelItem = this._travelItemRepository.getTravelItemOnTravelId(checkItem.TravelId).FirstOrDefault(e => e.Id == checkItem.ItemId);
                    if(travelItem != null)
                    {
                        travelItem.Checked = checkItem.Completed;
                        this._travelItemRepository.updateItem(travelItem);
                        this._travelItemRepository.SaveChanges();
                        return Ok();
                    }
                    return NoContent();
                }
                return NoContent();
            }
            return Unauthorized();
        }
        //Add Delete Categody
        [HttpDelete("{travelId}/Category/{categoryId}")]
        public async Task<IActionResult> RemoveTravelCategory(int travelId, int categoryId)
        {
            //Check if the user is authenticated
            if (User.Identity.IsAuthenticated)
            {
                var useraccount = await this._userManager.FindByNameAsync(User.Identity.Name);
                Traveler traveler = this._travelerRepository.getTraveler(useraccount);
                Category category = traveler.Categories.FirstOrDefault(e => e.Id == categoryId);
                Travel travel = traveler.Travels.FirstOrDefault(e => e.Id == travelId);
                if (travel != null && category != null)
                {
                    travel.Categories.Remove(category);
                    this._travelRepository.UpdateTravel(travel);
                    this._travelRepository.SaveChanges();
                    return Ok();
                }
                return NoContent();
            }
            return Unauthorized();
        }
        //Delete an travel of the curent user 
        [HttpDelete("{travelId}")]
        public async Task<IActionResult> RemoveTravel(int travelDTO)
        {
            //Check if the user is authenticated
            if (User.Identity.IsAuthenticated)
            {
                var useraccount = await this._userManager.FindByNameAsync(User.Identity.Name);
                Traveler traveler = this._travelerRepository.getTraveler(useraccount);
                Travel travel = traveler.Travels.FirstOrDefault(e => e.Id == travelDTO);
                if (travel != null)
                {
                    traveler.Travels.Remove(travel);
                    this._travelerRepository.SaveChanges();
                    return Ok();
                }
                return NotFound();
            }
            return Unauthorized();
        }
        //Add Delete Item
        [HttpDelete("{travelId}/Item/{itemId}")]
        public async Task<IActionResult> RemoveTravelItem(int travelId, int itemId)
        {
            //Check if the user is authenticated
            if (User.Identity.IsAuthenticated)
            {
                var useraccount = await this._userManager.FindByNameAsync(User.Identity.Name);
                Traveler traveler = this._travelerRepository.getTraveler(useraccount);
                Item item = this._itemRepository.GetItemsOnUserId(traveler.Id).FirstOrDefault(e => e.Id == itemId);
                Travel travel = traveler.Travels.FirstOrDefault(e => e.Id == travelId);
                if (travel != null && item != null)
                {
                    TravelItem travelItem = this._travelItemRepository.getTravelItemOnTravelId(travelId).FirstOrDefault(e => e.Item.Id == itemId);
                    if(travelItem != null)
                    {
                        this._travelItemRepository.removeItem(travelItem);
                        this._travelItemRepository.SaveChanges();
                        return Ok();
                    }
                    return NoContent();
                }
                return NoContent();
            }
            return Unauthorized();
        }
        //Add Delete 
        [HttpDelete("{travelId}/Task/{taskId}")]
        public async Task<IActionResult> RemoveTravelTask(int travelId, int taskId)
        {
            //Check if the user is authenticated
            if (User.Identity.IsAuthenticated)
            {
                var useraccount = await this._userManager.FindByNameAsync(User.Identity.Name);
                Traveler traveler = this._travelerRepository.getTraveler(useraccount);
                Models.Task task = traveler.Tasks.FirstOrDefault(e => e.Id == taskId);
                Travel travel = traveler.Travels.FirstOrDefault(e => e.Id == travelId);
                if (travel != null && task != null)
                {
                    TravelTask travelTask = this._travelTaskRepository.getTravelTaskOnTravelId(travelId).FirstOrDefault(e => e.Task.Id == taskId);
                    if(travelTask != null)
                    {
                        this._travelTaskRepository.removeTravelTask(travelTask);
                        this._travelTaskRepository.SaveChanges();
                        return Ok();
                    }
                    return NoContent();
                }
                return NoContent();
            }
            return Unauthorized();
        }
        //Remove Activity
        [HttpDelete("{travelId}/Activity/{activityId}")]
        public async Task<IActionResult> DeleteTravelActivity(int travelId ,int activityId)
        {
            if (User.Identity.IsAuthenticated)
            {
                var useraccount = await this._userManager.FindByNameAsync(User.Identity.Name);
                Traveler traveler = this._travelerRepository.getTraveler(useraccount);
                Travel travel = traveler.Travels.FirstOrDefault(e => e.Id == travelId);
                if (travel != null)
                {
                    Activity activity = travel.Iternary.FirstOrDefault(e => e.Id == activityId);
                    if (activity != null)
                    {
                        travel.Iternary.Remove(activity);
                        this._activityRepository.removeItem(activity);
                        this._activityRepository.SaveChanges();
                        this._travelRepository.UpdateTravel(travel);
                        this._travelerRepository.SaveChanges();
                        return Ok();
                    }
                    return NoContent();
                }
            }
            return Unauthorized();
        }        
    }
}
