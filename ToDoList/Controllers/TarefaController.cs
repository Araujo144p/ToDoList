using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Data;

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
    }
}