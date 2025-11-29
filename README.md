# 📝 To Do List — WebAPI

API desenvolvida com .NET para gerenciamento de tarefas, permitindo criar, listar, atualizar e excluir tarefas de forma simples e organizada.

---

## 🚀 Tecnologias utilizadas
- .NET 10
- C#  
- Entity Framework Core  
- Microsoft.EntityFrameworkCore.Design  
- Microsoft.EntityFrameworkCore.Tools  
- SQL Server  
- Scalar.AspNetCore (documentação dos endpoints)

---

## 🎯 Objetivo
Essa API oferece operações essenciais (CRUD) sobre uma tabela de tarefas:

| Ação            | Descrição |
|----------------|-----------|
| Criar tarefa   | Adiciona uma nova tarefa ao banco |
| Listar tarefas | Retorna todas as tarefas cadastradas |
| Buscar por ID  | Retorna uma tarefa específica |
| Editar tarefa  | Atualiza uma tarefa existente |
| Remover tarefa | Deleta uma tarefa cadastrada |

## 🗂️ Model principal

```csharp
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
```

---

## 📍 Endpoints
| Método | Endpoint       | Ação                       |
| ------ | -------------- | -------------------------- |
| GET    | `/tarefa`      | Buscar todas as tarefas    |
| GET    | `/tarefa/{id}` | Buscar tarefa por ID       |
| POST   | `/tarefa`      | Criar nova tarefa          |
| PUT    | `/tarefa/{id}` | Atualizar tarefa existente |
| DELETE | `/tarefa/{id}` | Remover tarefa             |

📌 Documentação interativa (Scalar):
Após rodar o projeto, acesse:
http://localhost:5094/scalar/v1 (ou a porta gerada na execução)

## 🛠️ Como executar o projeto
🔧 Pré-requisitos

.NET SDK 10+

SQL Server instalado e em execução

## 💾 Configuração do banco de dados

Abra o arquivo appsettings.json e configure a Connection String:

```
"ConnectionStrings": {
  "DefaultConnection": "server=SEU_SERVIDOR; database=Tarefas; trusted_connection=true; trustservercertificate=true"
}
```
## ▶️ Executando o projeto

Usando o terminal:
```
dotnet restore
dotnet ef database update   
dotnet run
```

## 🧪 Rodando os testes unitários

O projeto contém testes com xUnit.
```
dotnet test
```

## 📦 Dependências para rodar a API

| Pacote                                  | Finalidade                |
| --------------------------------------- | ------------------------- |
| Microsoft.EntityFrameworkCore           | ORM                       |
| Microsoft.EntityFrameworkCore.SqlServer | Provider SQL Server       |
| Microsoft.EntityFrameworkCore.Design    | Migrations                |
| Microsoft.EntityFrameworkCore.Tools     | CLI `dotnet ef`           |
| Scalar.AspNetCore                       | Documentação              |
| xUnit                                   | Testes unitários          |


