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
            ContaPersistence cp = new ContaPersistence();
            Conta c = new Conta();
            c.Descricao = "Salário";
            c.TipoConta = "R";
            c.IdGrupo = 2;

            int x = cp.Inserir(c);

            Assert.IsTrue(x > 0);
        }

        [TestMethod]
        public void Alterar()
        {
            ContaPersistence cp = new ContaPersistence();
            Conta c = cp.ObterPorId(2);
            c.Descricao = "Água";

            int x = cp.Atualizar(c);

            Assert.IsTrue(x > 0);
        }

        [TestMethod]
        public void ListarTodos()
        {
            ContaPersistence cp = new ContaPersistence();
            int x= cp.ListarTodos().Count;

            Assert.IsTrue(x > 0);
        }

        [TestMethod]
        public void Excluir()
        {
            ContaPersistence cp = new ContaPersistence();
            Conta c = cp.ObterPorId(1);
            int x = cp.Excluir(c);

            Assert.IsTrue(x > 0);
        }
    }
}
