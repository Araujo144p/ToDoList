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
        private readonly TarefaService _tarefaService;
        public TarefaController(TarefaService tarefaService)
        {
            _tarefaService = tarefaService;
        }


        // Endpoint GET - Buscar Tarefas
        [HttpGet]
        public ActionResult<List<TarefaModel>> BuscarTarefas()
        {
            var tarefas = _tarefaService.BuscarTarefas();
            return Ok(tarefas);
        }


        // Endpoint GET - Buscar Tarefa por id
        [HttpGet]
        [Route("{id}")]
        public ActionResult<TarefaModel> BuscarTarefaPorId(Guid id)
        {   
            var tarefa = _tarefaService.BuscarTarefaPorId(id);

            if(tarefa == null)
            {
                return BadRequest("Registro nao localizado!");
            }

            return Ok(tarefa);
        }

        // Endpoint POST - Criar Tarefa 
        [HttpPost]
        public ActionResult<TarefaModel> CriarTarefa(TarefaCreateDto tarefaDto)
        {
            var tarefa = _tarefaService.CriarTarefa(tarefaDto);
            if(tarefa == null)
            {
                return BadRequest("Ocorreu um erro na solicitacao");
            } 

            return CreatedAtAction(nameof(BuscarTarefaPorId), new {id = tarefa.Id}, tarefa );
        }


        // EndPoint PUT - ALterar Tarefa
        [HttpPut]
        [Route("{id}")]
        public ActionResult<TarefaModel> AlterarTarefa(TarefaUpdateDto tarefaDto, Guid id)
        {
            var tarefa = _tarefaService.AlterarTarefa(tarefaDto, id);

            if(tarefa == null)
            {
                return BadRequest("Registro não localizado!");
            }

            return NoContent();
        }

        // Endpoint Delete - Deletar Tarefa
        [HttpDelete]
        [Route("{id}")]
        public ActionResult<TarefaModel> DeletarTarefa( Guid id)
        {
            var tarefa = _tarefaService.DeletarTarefa(id);

            if(tarefa == null)
            {
                return BadRequest("Registro não localizado!");
            }

            return NoContent();
        }

        
    }

    
}