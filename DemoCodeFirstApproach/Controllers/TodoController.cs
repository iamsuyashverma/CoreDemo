using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using DemoCodeFirstApproach.Models;

namespace DemoCodeFirstApproach.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TodoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Todo
        [HttpGet]
        public ActionResult<IEnumerable<Todo>> GetTodos()
        {
            return _context.Todoes.ToList();
        }

        // GET: api/Todo/1
        [HttpGet("{id}")]
        public ActionResult<Todo> GetTodo(int id)
        {
            var todo = _context.Todoes.Find(id);
            if (todo == null)
            {
                return NotFound();
            }
            return todo;
        }

        // POST: api/Todo
        [HttpPost]
        public ActionResult<Todo> CreateTodo(Todo todo)
        {
            if (todo == null)
            {
                return BadRequest();
            }
            _context.Todoes.Add(todo);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetTodo), new { id = todo.Id }, todo);
        }
    }
}
