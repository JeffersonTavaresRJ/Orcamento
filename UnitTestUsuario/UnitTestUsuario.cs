using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Project.Entity;
using Project.Repository.Persistence;
using Project.Utility.UtilString;

namespace UnitTestPersistence
{
    [TestClass]
    public class UnitTestUsuario
    {
        [TestMethod]
        public void Adicionar()
        {

            Usuario u = new Usuario();
            u.IdUsuario = "B9GY";
            u.Nome = "Jefferson Silva Tavares";
            u.Senha = Criptografia.EncriptarSenha("ABC123");

            UsuarioPersistence up = new UsuarioPersistence();

            int i = up.Inserir(u);

            Assert.IsTrue(i > 0);
            Assert.IsFalse(i == 0);


        }

        [TestMethod]
        public void Alterar()
        {

            UsuarioPersistence up = new UsuarioPersistence();

            Usuario u = up.ObterLoginSenha("B9GY", Criptografia.EncriptarSenha("ABC123"));

            u.Nome = "Jefferson Petrobras";

            int i = up.Atualizar(u);

            Assert.IsTrue(i == 1);


        }

        [TestMethod]
        public void Excluir()
        {

            UsuarioPersistence up = new UsuarioPersistence();

            Usuario u = up.ObterPorId("B9GY");

            int i = up.Excluir(u);

            Assert.IsTrue(i == 1);


        }

        [TestMethod]
        public void ListarTodos()
        {

            UsuarioPersistence up = new UsuarioPersistence();

            List<Usuario> lista = up.ListarTodos();

            Assert.IsTrue(lista.Count == 5);
            Assert.IsFalse(lista.Count == 0);


        }

        [TestMethod]
        public void ObterLoginSenha()
        {

            UsuarioPersistence up = new UsuarioPersistence();

            Usuario u = up.ObterLoginSenha("B9GY", Criptografia.EncriptarSenha("ABC123"));

            Assert.IsTrue(u != null);


        }

        [TestMethod]
        public void LoginExistente()
        {

            UsuarioPersistence up = new UsuarioPersistence();

            int i = up.LoginExistente("TSRV");

            Assert.IsTrue(i == 1);

        }

        [TestMethod]
        public void RemoverMenu()
        {

            PerfilPersistence pp = new PerfilPersistence();
            Perfil p = pp.ObterPorId(6);

            MenuPersistence mp = new MenuPersistence();
            Menu m = mp.ObterPorId(13);

            int i = pp.RemoverMenu(p, m);

            Assert.IsTrue(i == 1);

        }

    }
}
