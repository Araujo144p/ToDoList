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

        public List<TarefaModel> BuscarTarefas()
        {
            return _context.Tarefas.ToList();
        }
    }
}
