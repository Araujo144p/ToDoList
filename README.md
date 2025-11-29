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

Os endpoints podem ser visualizados via Scalar.

## 🛠️ Como executar o projeto
🔧 Pré-requisitos

.NET SDK 10+

SQL Server instalado e em execução

## 💾 Configuração do banco de dados

Abra o arquivo appsettings.json e configure a Connection String:

```
"ConnectionStrings": {
  "DefaultConnection": "server=DESKTOP-PLOL2QK\\SQLEXPRESS; database=Tarefas; trusted_connection=true; trustservercertificate=true"
}
```
## ▶️ Executando o projeto

Usando o terminal:
```
dotnet ef database update   
dotnet run
```

## 📦 Dependências para rodar a API

| Pacote                                  | Função                     |
| --------------------------------------- | -------------------------- |
| Microsoft.EntityFrameworkCore           | ORM                        |
| Microsoft.EntityFrameworkCore.SqlServer | Provider SQL Server        |
| Microsoft.EntityFrameworkCore.Design    | Suporte a Migrations       |
| Microsoft.EntityFrameworkCore.Tools     | Comandos CLI (`dotnet ef`) |
| Scalar.AspNetCore                       | Documentação da API        |

