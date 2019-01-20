using Project.Entity;
using System.Collections.Generic;
using System.Linq;//para fazer o comando where..
using System.Data.Entity;//para fazer o include..

namespace Project.Repository.Persistence
{
    public class PerfilPersistence : GenericRepository<Perfil>
    {

        public int InserirPerfilMenu(Perfil perfil, List<int> idMenus)
        {
            //função cria um novo perfil com vários menus..

            foreach (var item in idMenus)
            {
                //não utiliza o método de inserção do Perfil para usar um único context 
                //para realizar a gravação do perfil e menu juntos. Se utilizar context's diferentes (persistentes Perfil e Menu),
                //não grava, apresentanto erro..
                Menu m = new Menu();
                m = _conn.Menu.Find(item);

                perfil.Menus.Add(m);
            }
            _conn.Perfil.Add(perfil);
            return _conn.SaveChanges();
        }

        public int RemoverMenu(Perfil p, Menu m)
        {
            //método que remove o menu de um perfil..

            Perfil perfil = _conn.Perfil.Include(x => x.Menus)
                                        .FirstOrDefault(x => x.Id.Equals(p.Id));
            perfil.Menus.Remove(m);
            return _conn.SaveChanges();
        }

        public int IncluiMenu(int idPerfil, int idMenu)
        {
            Menu menu = _conn.Menu.Find(idMenu);

            Perfil perfil = _conn.Perfil.Include(x => x.Menus)
                                        .FirstOrDefault(x => x.Id.Equals(idPerfil));
            perfil.Menus.Add(menu);
            return _conn.SaveChanges();
        }

        public List<Perfil> ObterPorDescricao(string nome)
        {
            return _conn.Perfil.Where(p => p.Descricao.Contains(nome)).ToList();

        }

        public ICollection<Menu> ObterMenus(int idPerfil)
        {
            Perfil perfil = _conn.Perfil.Include(p => p.Menus)
                                        .FirstOrDefault(p => p.Id.Equals(idPerfil));

            return perfil.Menus;

        }

        public List<Usuario> ObterUsuarios(int idPerfil)
        {
            Perfil perfil = _conn.Perfil.Include(p => p.Usuarios)
                                        .FirstOrDefault(p => p.Id.Equals(idPerfil));
            return perfil.Usuarios;
        }

    }
}
