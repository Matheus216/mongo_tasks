using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using mongo_dotnet_ep1.Models;
using mongo_dotnet_ep1.Services;

namespace mongo_dotnet_ep1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService service; 

        public TaskController(ITaskService task)
        {
            service = task;  
        }

        // GET api/task
        public ActionResult<IList<TaskModel>> GetTask()
        {
            var tasks = service.Get(); 

            if (tasks == null)
            {
                return NoContent();
            }

            return Ok(tasks); 
        }

        // GET api/task/5
        [HttpGet("{id:length(24)}", Name = "GetTask")]
        public ActionResult<string> GetTask(string id)
        {
            var tasks = service.Get(id); 

            if (tasks == null)
            {
                return NoContent();
            }

            return Ok(tasks); 
        }

        // POST api/task
        [HttpPost("Created")]
        public ActionResult<TaskModel> Created([FromBody]TaskModel task)
        {
            service.Create(task);

            return Ok(task); 
        }

        // PUT api/task/5
        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, [FromBody]TaskModel task)
        {
            var antTask = service.Get(id); 

            if(antTask == null)
            {
                return NoContent(); 
            }

            service.Update(id, task); 

            return NoContent(); 
        }

        // DELETE api/task/5
        [HttpDelete("{id:length(24)}")]
        public IActionResult DeletestringById(string id)
        {
            var search = service.Get(id); 

            if (search == null)
            {
                return NotFound(); 
            }

            service.Remove(search._id); 

            return Ok(); 
        }
    }
}