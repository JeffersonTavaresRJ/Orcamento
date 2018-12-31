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

        public int ExcluirPerfilMenu(Perfil p, Menu m)
        {
            PerfilMenuPersistence pmp = new PerfilMenuPersistence();

            PerfilMenu pm = new PerfilMenu();
            pm.Perfil = p;
            pm.Menu = m;

            return pmp.Excluir(pm);
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
    }
}
