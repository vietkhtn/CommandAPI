using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace CommandAPI.AddControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] {"this","is","hard","code"};
        }
    }
}