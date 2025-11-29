using ToDoList.Models;
using ToDoList.Services;
using ToDoList.DTOs;
using ToDoList.Data;

namespace ToDoList.Tests
{
    public class TarefaServiceTests
    {
        [Fact]
        public void BuscarTarefas_DeveRetornarListaDeTarefas()
        {
            var db = DbHelper.CriarDbInMemory();
            db.Tarefas.Add(new TarefaModel("T1", "D1"));
            db.Tarefas.Add(new TarefaModel("T2", "D2"));
            db.SaveChanges();

            var service = new TarefaService(db);

            var resultado = service.BuscarTarefas();

            Assert.Equal(2, resultado.Count);
        }

        [Fact]
        public void BuscarTarefaPorId_DeveRetornarTarefaQuandoExiste()
        {
            var db = DbHelper.CriarDbInMemory();
            var tarefa = new TarefaModel("Teste", "Teste");
            db.Tarefas.Add(tarefa);
            db.SaveChanges();

            var service = new TarefaService(db);

            var resultado = service.BuscarTarefaPorId(tarefa.Id);

            Assert.NotNull(resultado);
            Assert.Equal(tarefa.Id, resultado?.Id);
        }

        [Fact]
        public void BuscarTarefaPorId_DeveRetornarNullQuandoNaoExiste()
        {
            var db = DbHelper.CriarDbInMemory();
            var service = new TarefaService(db);

            var resultado = service.BuscarTarefaPorId(Guid.NewGuid());

            Assert.Null(resultado);
        }

        [Fact]
        public void CriarTarefa_DeveCriarQuandoDtoValido()
        {
            var db = DbHelper.CriarDbInMemory();
            var service = new TarefaService(db);
            var dto = new TarefaCreateDto { Nome = "Teste", Descricao = "Desc" };

            var resultado = service.CriarTarefa(dto);

            Assert.NotNull(resultado);
            Assert.Equal("Teste", resultado?.Nome);
            Assert.Equal(1, db.Tarefas.Count());
        }

        [Fact]
        public void CriarTarefa_DeveRetornarNullQuandoDtoNulo()
        {
            var db = DbHelper.CriarDbInMemory();
            var service = new TarefaService(db);

            var resultado = service.CriarTarefa(null);

            Assert.Null(resultado);
        }

        [Fact]
        public void AlterarTarefa_DeveAtualizarCamposEnviados()
        {
            var db = DbHelper.CriarDbInMemory();
            var tarefa = new TarefaModel("Antes", "Antes", false);
            db.Tarefas.Add(tarefa);
            db.SaveChanges();

            var service = new TarefaService(db);
            var dto = new TarefaUpdateDto
            {
                Nome = "Depois",
                Descricao = "Nova descricao",
                Concluida = true
            };

            var resultado = service.AlterarTarefa(dto, tarefa.Id);

            Assert.NotNull(resultado);
            Assert.Equal("Depois", resultado!.Nome);
            Assert.Equal("Nova descricao", resultado.Descricao);
            Assert.True(resultado.Concluida);
        }

        [Fact]
        public void AlterarTarefa_DeveRetornarNullQuandoNaoExiste()
        {
            var db = DbHelper.CriarDbInMemory();
            var service = new TarefaService(db);
            var dto = new TarefaUpdateDto();

            var resultado = service.AlterarTarefa(dto, Guid.NewGuid());

            Assert.Null(resultado);
        }

        [Fact]
        public void DeletarTarefa_DeveRemoverQuandoExiste()
        {
            var db = DbHelper.CriarDbInMemory();
            var tarefa = new TarefaModel("Teste", "Teste");
            db.Tarefas.Add(tarefa);
            db.SaveChanges();

            var service = new TarefaService(db);

            var resultado = service.DeletarTarefa(tarefa.Id);

            Assert.NotNull(resultado);
            Assert.Equal(0, db.Tarefas.Count());
        }

        [Fact]
        public void DeletarTarefa_DeveRetornarNullQuandoNaoExiste()
        {
            var db = DbHelper.CriarDbInMemory();
            var service = new TarefaService(db);

            var resultado = service.DeletarTarefa(Guid.NewGuid());

            Assert.Null(resultado);
        }
    }
}
