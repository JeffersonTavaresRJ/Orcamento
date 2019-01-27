using Microsoft.VisualStudio.TestTools.UnitTesting;
using Project.Entity;
using Project.Repository.Persistence;
using System.Collections.Generic;

namespace UnitTestPersistence
{
    [TestClass]
    public class UnitTestGrupo
    {
        [TestMethod]
        public void Incluir()
        {
            GrupoPersistence gp = new GrupoPersistence();
            Grupo g = new Grupo();
            g.Descricao = "Extra";
            int i =  gp.Inserir(g);

            Assert.IsTrue(i > 0);
        }

        [TestMethod]
        public void Alterar()
        {
            GrupoPersistence gp = new GrupoPersistence();
            Grupo g = new Grupo();
            g.Id = 1;
            g.Descricao = "Intermediário";
            int i = gp.Atualizar(g);

            Assert.IsTrue(i > 0);
        }

        [TestMethod]
        public void ListarTodos()
        {
            GrupoPersistence gp = new GrupoPersistence();
            List<Grupo> lista = gp.ListarTodos();

            Assert.IsTrue(lista.Count > 0);
        }

        [TestMethod]
        public void ObterPorId()
        {
            GrupoPersistence gp = new GrupoPersistence();
            Grupo g = gp.ObterPorId(1);

            Assert.IsTrue(g != null);
        }

        [TestMethod]
        public void Excluir()
        {
            GrupoPersistence gp = new GrupoPersistence();
            Grupo g = gp.ObterPorId(1);
            int i = gp.Excluir(g);

            Assert.IsTrue(i >0);
        }

    }
}
