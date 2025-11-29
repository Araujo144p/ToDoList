using ToDoList.Data;
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
    }
}
