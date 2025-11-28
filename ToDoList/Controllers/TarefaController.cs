using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Data;
using ToDoList.Models;

namespace ToDoList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class TarefaController: ControllerBase
    {
        private readonly TarefaDbContext _context;
        public TarefaController(TarefaDbContext context)
        {
            _context = context;
        }



        [HttpGet]
        public ActionResult<List<TarefaModel>> BuscarTarefas()
        {
            var tarefas = _context.Tarefas.ToList();

            return Ok(tarefas);
        }



        [HttpGet]
        [Route("{id}")]

        public ActionResult<TarefaModel> BuscarTarefaPorId(Guid id)
        {   
            var tarefa = _context.Tarefas.Find(id);

            if(tarefa == null)
            {
                return NotFound("Registro não localizado!");
            }

            return Ok(tarefa);
        }

        
    }

    
}