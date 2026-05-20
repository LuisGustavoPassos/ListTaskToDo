using Microsoft.AspNetCore.Mvc;
using ToDo.Data;
using ToDo.Models;

namespace ToDo.Controllers
{
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        [Route("/")]
        public List<TodoModel> Get([FromServices] AppDbContext context )
        {
            {
                return context.Todos.ToList();
            }
        }

       [HttpGet("/{id:int}")]

        public TodoModel GetById(
            [FromRoute] int id,
            [FromServices] AppDbContext context )
        {
            {
                return context.Todos.FirstOrDefault(x=>x.Id == id);
            }
        }


        [HttpPost]
        [Route("/")]
        public TodoModel Post(
        [FromBody] TodoModel todo, 
        [FromServices] AppDbContext context)
        {
            context.Todos.Add(todo);
            context.SaveChanges();
            return todo;
        }

        [HttpPut("/{id:int}")]
        public TodoModel Put(
            [FromRoute] int id,
            [FromBody] TodoModel todo, 
             [FromServices] AppDbContext context)
          {
        var model = context.Todos.FirstOrDefault(x => x.Id == id);
        if (model == null)            
            return todo;    
  
            model.Title = todo.Title;
            model.Done = todo.Done;
            context.Todos.Update(model);
            context.SaveChanges();
            return model;
        }
        
        [HttpDelete("/{id:int}")]
        public IActionResult Delete(
            [FromRoute] int id,
            [FromServices] AppDbContext context)
        {
            var model = context.Todos.FirstOrDefault(x => x.Id == id);
            if (model == null)
                return NotFound();
            context.Todos.Remove(model);
            context.SaveChanges();
            return Ok(model);}
}
}