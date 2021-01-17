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
    public class TaskController : Controller
    {

        private readonly ITravelerRepository _travelerRepository;
        private readonly ITaskRepository _taskRepository;
        private readonly UserManager<ApplicationUser> _userManager;

        public TaskController(ITravelerRepository travelerRepository, ITaskRepository taskRepository, UserManager<ApplicationUser> userManager)
        {
            _travelerRepository = travelerRepository;
            _taskRepository = taskRepository;
            _userManager = userManager;
        }
        //Get all the task for thee current user
        [HttpGet()]
        public async Task<List<TaskDTO>> GetTask()
        {
            if (User.Identity.IsAuthenticated)
            {
                var useraccount = await this._userManager.FindByNameAsync(User.Identity.Name);
                Traveler traveler = this._travelerRepository.getTraveler(useraccount);
                Models.Task[] tasks = traveler.Tasks.ToArray();
                List<TaskDTO> dto = new List<TaskDTO>();
                foreach (var item in tasks)
                {
                    dto.Add(new TaskDTO() { Id = item.Id, Description = item.Description });
                }
                Response.StatusCode = 200;
                return dto;
            }
            Response.StatusCode = 401;
            return null;
        }
        //Create a task for the curent user
        [HttpPost()]
        public async Task<IActionResult> CreateTask(TaskDTO taskDTO)
        {
            //Check if the user is authenticated
            if (User.Identity.IsAuthenticated)
            {
                //Add item with current traveler
                var useraccount = await this._userManager.FindByNameAsync(User.Identity.Name);
                Traveler traveler = this._travelerRepository.getTraveler(useraccount);
                Models.Task task = new Models.Task(taskDTO.Description);
                traveler.Tasks.Add(task);
                this._travelerRepository.updateTraveler(traveler);
                this._travelerRepository.SaveChanges();
                return Ok();
            }
            return Unauthorized();
        }
        //Delete a task of the curent user 
        [HttpDelete("{taskId}")]
        public async Task<IActionResult> DeleteTask(int taskId)
        {
            //Check if the user is authenticated
            if (User.Identity.IsAuthenticated)
            {
                //Add item with current traveler
                var useraccount = await this._userManager.FindByNameAsync(User.Identity.Name);
                Traveler traveler = this._travelerRepository.getTraveler(useraccount);
                Models.Task task = traveler.Tasks.FirstOrDefault(e => e.Id == taskId);
                if(task != null)
                {
                    this._taskRepository.RemoveTask(task);
                    this._taskRepository.SaveChanges();
                    return Ok();
                }
                NoContent();
            }
            return Unauthorized();
        }
    }
}
