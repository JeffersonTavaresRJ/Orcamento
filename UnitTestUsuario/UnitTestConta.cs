using Microsoft.VisualStudio.TestTools.UnitTesting;
using Project.Entity;
using Project.Repository.Persistence;

namespace UnitTestPersistence
{
    public class UnitTestConta
    {
        [TestMethod]
        public void IncluirConta()
        {
            ContaPersistence cp = new ContaPersistence();
            Conta c = new Conta();
            c.IdGrupo = 2;
            c.TipoConta = "D";
            c.Descricao = "ÁGUA";
            int i = cp.Inserir(c);

            Assert.IsTrue(i > 0);
        }

        //[TestMethod]
        //public void Alterar()
        //{
        //    GrupoPersistence gp = new GrupoPersistence();
        //    Grupo g = new Grupo();
        //    g.Id = 1;
        //    g.Descricao = "Intermediário";
        //    int i = gp.Atualizar(g);

        //    Assert.IsTrue(i > 0);
        //}

        //[TestMethod]
        //public void ListarTodos()
        //{
        //    GrupoPersistence gp = new GrupoPersistence();
        //    List<Grupo> lista = gp.ListarTodos();

        //    Assert.IsTrue(lista.Count > 0);
        //}

        //[TestMethod]
        //public void ObterPorId()
        //{
        //    GrupoPersistence gp = new GrupoPersistence();
        //    Grupo g = gp.ObterPorId(1);

        //    Assert.IsTrue(g != null);
        //}

        //[TestMethod]
        //public void Excluir()
        //{
        //    GrupoPersistence gp = new GrupoPersistence();
        //    Grupo g = gp.ObterPorId(1);
        //    int i = gp.Excluir(g);

        //    Assert.IsTrue(i > 0);
        //}
    }
}
