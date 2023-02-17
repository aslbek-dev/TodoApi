using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;
using TodoApi.Data;

namespace TodoApi.Controllers
{  
    [Route("username/items")]
    [ApiController]
    public class TodoItemController : ControllerBase
    {
       private readonly TodoContext todoContext;
       public TodoItemController(TodoContext todoContext)
       {
        this.todoContext = todoContext;
       }
       [HttpPost]
       public async Task<IActionResult>  PosttoItem (TodoItem todoItem)
       {
        this.todoContext.Add(todoItem);
        await this.todoContext.SaveChangesAsync();
        return Ok(todoItem);
       }
       [HttpGet("{userr_id}")]
       public async Task<IActionResult> GetAllTodoItem(int userr_id)
       {
            var list = this.todoContext.TodoItems.FindAsync(userr_id);
            return Ok(list);
       }
       
       [HttpPut("{userr_id}")]
       public async Task<IActionResult> PutTodoItem(int userr_id, TodoItem todoItem)
       {
         var storagetodoItem = await this.todoContext.TodoItems.FindAsync(userr_id);
         if (todoItem is null)
            return NotFound();
        storagetodoItem.Name = todoItem.Name;
        storagetodoItem.Description = todoItem.Description;
        storagetodoItem.IsComplete = todoItem.IsComplete;
        await this.todoContext.SaveChangesAsync();
        return Ok(storagetodoItem);
       }
    }
}