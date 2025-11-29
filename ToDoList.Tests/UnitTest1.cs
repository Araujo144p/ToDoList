using Microsoft.EntityFrameworkCore;
using ToDoList.Data;

namespace ToDoList.Tests
{
    public static class DbHelper
    {
        public static TarefaDbContext CriarDbInMemory()
        {
            var options = new DbContextOptionsBuilder<TarefaDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            return new TarefaDbContext(options);
        }
    }
}
