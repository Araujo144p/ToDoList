using System.ComponentModel.DataAnnotations;

namespace ToDoList.DTOs
{
    public class TarefaCreateDto
    {
        [Required]
        [MinLength(3)]
        public string Nome { get; set; } = String.Empty;
        public string Descricao { get; set; } = String.Empty;
    }
}
