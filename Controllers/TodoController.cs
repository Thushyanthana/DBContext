using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApi.Models;

namespace TodoApi.Controllers
{
    //[ApiController] is a attribute
    //It indicates that respond to http request
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly TodoContext _context;

        public TodoController(TodoContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoItem>>> GetTodoItems()
        {
            //using await helps to convert the IEnumerable to TodoItems.
            return await _context.TodoItems.ToListAsync();
        }


        [HttpGet("{Id}")]
        public async Task<ActionResult<TodoItem>> GetTodoItem(long Id)
        {
            var todoItem = await _context.TodoItems.FindAsync(Id);

            if(todoItem==null)
            {
                return NotFound();
            }
            return todoItem;
        }


        [HttpPost]
        public async Task<ActionResult<TodoItem>> PostTodoItem(TodoItem todoItem ,String Id )
        {
            _context.TodoItems.Add(todoItem);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetTodoItem", new { id = todoItem.Id }, todoItem);
            return CreatedAtAction(nameof(GetTodoItem), new { id = todoItem.Id }, todoItem);
        }



        [HttpPut("{Id}")]
        public async Task<ActionResult>  putTodoItem(long Id,[FromBody]TodoItem todoItem)
        {
            if(Id!= todoItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(todoItem).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok(todoItem);
            //return NoContent();
        }



        [HttpDelete ("{Id}")]
        public  async Task<IActionResult> DeleteTodoItem(long Id)
        {
            var todoItem = await _context.TodoItems.FindAsync(Id);

            if (todoItem == null)
            {
                return NotFound();
            }

            _context.TodoItems.Remove(todoItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}
