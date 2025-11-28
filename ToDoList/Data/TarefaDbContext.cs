using Microsoft.EntityFrameworkCore;
using ToDoList.Models;

namespace ToDoList.Data
{
    public class TarefaDbContext: DbContext
    {
        public TarefaDbContext(DbContextOptions<TarefaDbContext> options) : base(options)
        {    
        }

        public DbSet<TarefaModel> Tarefas { get; set; }
    }
}
