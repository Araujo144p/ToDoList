namespace ToDoList.Models;

public class TarefaModel
{
    public TarefaModel(string nome, string descricao, bool concluida = false)
    {
        Id = Guid.NewGuid();
        DataCriação = DateTime.Now;
        Nome = nome;
        Descricao = descricao;
        Concluida = concluida;
    }

    public Guid Id { get; init; }
    public DateTime DataCriação {get; init;}
    public string Nome { get; set; } = String.Empty;
    public string Descricao { get; set; } = String.Empty;
    public bool Concluida {get; set;} = false;
}