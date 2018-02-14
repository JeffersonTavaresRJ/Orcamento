using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Project.Entity;
using Project.Repository.Persistence;
using Project.Web;
using Project.Util;

namespace UnitTestUsuario
{
    [TestClass]
    public class UnitTestAdicionar
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

            Assert.IsTrue(lista.Count ==5);
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

            int i = up.LoginExistente("B9GY");

            Assert.IsTrue(i==1);


        }



    }
}
