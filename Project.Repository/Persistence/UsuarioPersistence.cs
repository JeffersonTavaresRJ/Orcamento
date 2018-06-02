using System.Linq;
using Project.Entity;
using System.Data.Entity;
using System.Collections.Generic;

namespace Project.Repository.Persistence
{
    public class UsuarioPersistence : GenericRepository<Usuario>
    {
        public Usuario ObterLoginSenha(string _login, string _senha)
        {

            return _conn.Usuario
                              .Include(u=>u.Perfil)
                              .Include(p=>p.Perfil.Menus)
                              .FirstOrDefault(u => u.IdUsuario.Equals(_login) &&
                                                   u.Senha.Equals(_senha));

        }

        public override List<Usuario> ListarTodos()
        {
            return _conn.Usuario
                .Include(u => u.Perfil)
                .ToList();
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
