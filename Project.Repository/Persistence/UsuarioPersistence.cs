using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;
using Project.Entity;


using Project.Repository.Configurations;

namespace Project.Repository.Persistence
{
    public class UsuarioPersistence : GenericRepository<Usuario>
    {
        public Usuario ObterLoginSenha(string _login, string _senha)
        {

            return _conn.Usuario.FirstOrDefault(
                u => u.IdUsuario.Equals(_login) &&
                     u.Senha.Equals(_senha));

        }

        public int LoginExistente(string _login)
        {

            return _conn.Usuario.Count(u => u.IdUsuario.Equals(_login));

        }

        public Usuario ObterPorId(string _Id)
        {

            return _conn.Usuario.FirstOrDefault(u => u.IdUsuario.Equals(_Id));

        }

    }
}
