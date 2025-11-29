using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Data;
using ToDoList.DTOs;
using ToDoList.Models;
using ToDoList.Services;

namespace ToDoList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class TarefaController: ControllerBase
    {
        private readonly TarefaDbContext _context;
        private readonly TarefaService _tarefaService;
        public TarefaController(TarefaDbContext context, TarefaService tarefaService)
        {
            _context = context;
            _tarefaService = tarefaService;
        }


        // Endpoint GET - Buscar Tarefas
        [HttpGet]
        public ActionResult<List<TarefaModel>> BuscarTarefas()
        {
            var tarefas = _tarefaService.BuscarTarefas();
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

        public ActionResult<TarefaModel> CriarTarefa(TarefaCreateDto tarefaDto)
        {
            if(tarefaDto == null)
            {
                return BadRequest("Ocorreu um erro na solicitacao");
            }

            var tarefa = new TarefaModel(tarefaDto.Nome, tarefaDto.Descrição);

            _context.Tarefas.Add(tarefa);
            _context.SaveChanges();

            return CreatedAtAction(nameof(BuscarTarefaPorId), new {id = tarefa.Id}, tarefa );
        }

        [HttpPut]
        [Route("{id}")]

        public ActionResult<TarefaModel> AlterarTarefa(TarefaUpdateDto tarefaDto, Guid id)
        {
            var tarefa = _context.Tarefas.Find(id);

            if(tarefa == null)
            {
                return BadRequest("Registro não localizado!");
            }

            tarefa.Nome = tarefaDto.Nome;
            tarefa.Descricao = tarefaDto.Descricao;
            tarefa.Concluida = tarefaDto.Concluida;

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