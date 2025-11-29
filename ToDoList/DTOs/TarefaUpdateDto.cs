namespace ToDoList.DTOs
{
    public class TarefaUpdateDto
    {
        public string Nome { get; set; } = String.Empty;
        public string Descricao { get; set; } = String.Empty;
        public bool? Concluida {get; set;} = false;
    }
}