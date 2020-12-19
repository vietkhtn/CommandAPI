using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using CommandAPI.Data;
using CommandAPI.Models;

namespace CommandAPI.AddControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        //Dependency Injection Pattern
        private readonly ICommandAPIRepo _repository; // tạo trường _repositiry để gán đối tượng (MockCommandAPi) vào contructor

        // Khi Controller đc gọi, DI sẽ đưa đoạn code chức năng (MockAPICommand) vào Interface (ICommandAPI), liên kết tạo ở AddScoped trong Startup.cs
        public CommandsController(ICommandAPIRepo repository) 
        {
            _repository = repository;
        }

        //CommandsController.cs
        [HttpGet]
        public ActionResult<IEnumerable<Command>> GetAllCommands()
        {
            var commandItems = _repository.GetAllCommands();
            return Ok(commandItems);
        }

        [HttpGet("{id}")]
        public ActionResult<IEnumerable<Command>> GetCommandById(int id)
        {
            var commandItem = _repository.GetCommandById(id);
            if (commandItem == null)
            {
                return NotFound();
            }
            return Ok(commandItem);
        }
    }
}