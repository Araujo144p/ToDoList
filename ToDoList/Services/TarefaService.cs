using Microsoft.AspNetCore.Mvc;
using ToDoList.Data;
using ToDoList.DTOs;
using ToDoList.Models;

namespace ToDoList.Services
{
    public class TarefaService
    {
        private readonly TarefaDbContext _context;

        public TarefaService(TarefaDbContext context)
        {
            _context = context;
        }

        // Logica do endpoint GET - Buscar Tarefas
        public List<TarefaModel> BuscarTarefas()
        {
            return _context.Tarefas.ToList();
        }


        // Logica do endpoint GET - Buscar Tarefas por id
        public TarefaModel? BuscarTarefaPorId(Guid id)
        {
            var tarefa = _context.Tarefas.Find(id);

            if (tarefa == null)
            {
                return null;
            }

            return tarefa;
        }

        // Logica do endpoint POST - Criar Tarefa
        public TarefaModel? CriarTarefa(TarefaCreateDto tarefaDto)
        {
            if (tarefaDto == null)
            {
                return null;
            }

            var tarefa = new TarefaModel(tarefaDto.Nome, tarefaDto.Descricao);
            return tarefa;
        }

        // Logica do endpoint PUT - Alterar Tarefa
        public TarefaModel? AlterarTarefa(TarefaUpdateDto tarefaUpdateDto, Guid id)
        {
            var tarefa = _context.Tarefas.Find(id);

            if (tarefa == null)
            {
                return null;
            }

            if (!string.IsNullOrWhiteSpace(tarefaUpdateDto.Nome))
                tarefa.Nome = tarefaUpdateDto.Nome;

            if (!string.IsNullOrWhiteSpace(tarefaUpdateDto.Descricao))
                tarefa.Descricao = tarefaUpdateDto.Descricao;

            if (tarefaUpdateDto.Concluida  != null)
                tarefa.Concluida = tarefaUpdateDto.Concluida.Value;

            return tarefa;
        }

        public TarefaModel? DeletarTarefa(Guid id)
        {
            var tarefa = _context.Tarefas.Find(id);

            if(tarefa == null)
            {
                return null;
            }

            _context.Tarefas.Remove(tarefa);
            _context.SaveChanges();

            return tarefa;
        }
    }
}
