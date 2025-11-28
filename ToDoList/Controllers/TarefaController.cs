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

        [HttpPost]

        public ActionResult<TarefaModel> CriarTarefa(TarefaModel tarefaModel)
        {
            if(tarefaModel == null)
            {
                return BadRequest("Ocorreu um erro na solicitacao");
            }

            _context.Tarefas.Add(tarefaModel);
            _context.SaveChanges();

            return CreatedAtAction(nameof(BuscarTarefaPorId), new {id = tarefaModel.Id}, tarefaModel);
        }

        [HttpPut]
        [Route("{id}")]

        public ActionResult<TarefaModel> AlterarTarefa(TarefaModel tarefaModel, Guid id)
        {
            var tarefa = _context.Tarefas.Find(id);

            if(tarefa == null)
            {
                return BadRequest("Registro não localizado!");
            }

            tarefa.Nome = tarefaModel.Nome;
            tarefa.Descricao = tarefaModel.Descricao;
            tarefa.Concluida = tarefaModel.Concluida;

            _context.Tarefas.Update(tarefa);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete]
        [Route("{id}")]

        public ActionResult<TarefaModel> DeletarTarefa( Guid id)
        {
            var tarefa = _context.Tarefas.Find(id);

            if(tarefa == null)
            {
                return BadRequest("Registro não localizado!");
            }

            _context.Tarefas.Remove(tarefa);
            _context.SaveChanges();

            return NoContent();
        }

        
    }

    
}