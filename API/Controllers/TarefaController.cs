using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TesteApp.Models;
using TesteApp.Services;

namespace TesteApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TarefaController : ControllerBase
    {
        public TarefaController()
        {          
        }

        [HttpGet]
        public ActionResult<List<TodoItem>> GetAll() => TarefaService.GetAll();
        
        [HttpGet("{id}")]
        public ActionResult<TodoItem> Get(int id)
        {
            var tarefas = TarefaService.Get(id);
            if (tarefas == null)
                return NotFound();
            return tarefas;
        }

        [HttpPost]
        public IActionResult Create(TodoItem tarefas)
        {
            TarefaService.Add(tarefas);
            return CreatedAtAction(nameof(Create), new {id = tarefas.Id}, tarefas);
        }
        
        [HttpPut("{id}")]
        public IActionResult Update(int id, TodoItem tarefas)
        {
            if (id != tarefas.Id)
                return BadRequest();

            var existingTarefa = TarefaService.Get(id);

            if (existingTarefa is null)
                return NotFound();

            TarefaService.Update(tarefas);
            return NoContent();
        }
        
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var tarefa = TarefaService.Get(id);
            if (tarefa is null)
                return NotFound();
            TarefaService.Delete(id);
            return NoContent();
        }
    }
}