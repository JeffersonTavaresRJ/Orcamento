using Microsoft.VisualStudio.TestTools.UnitTesting;
using Project.Entity;
using Project.Repository.Persistence;

namespace UnitTestPersistenceOrcamento
{
    [TestClass]
    public class UTConta
    {
        [TestMethod]
        public void Incluir()
        {
            ItemContaPersistence cp = new ItemContaPersistence();
            ItemConta c = new ItemConta();
            c.Descricao = "Salário";
            c.TipoItemConta = "R";
            c.IdGrupo = 2;

            int x = cp.Inserir(c);

            Assert.IsTrue(x > 0);
        }

        [TestMethod]
        public void Alterar()
        {
            ItemContaPersistence cp = new ItemContaPersistence();
            ItemConta c = cp.ObterPorId(2);
            c.Descricao = "Água";

            int x = cp.Atualizar(c);

            Assert.IsTrue(x > 0);
        }

        [TestMethod]
        public void ListarTodos()
        {
            ItemContaPersistence cp = new ItemContaPersistence();
            int x= cp.ListarTodos().Count;

            Assert.IsTrue(x > 0);
        }

        [TestMethod]
        public void Excluir()
        {
            ItemContaPersistence cp = new ItemContaPersistence();
            ItemConta c = cp.ObterPorId(1);
            int x = cp.Excluir(c);

            Assert.IsTrue(x > 0);
        }
    }
}
