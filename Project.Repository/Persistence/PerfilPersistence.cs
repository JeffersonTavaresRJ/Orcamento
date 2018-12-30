using Project.Entity;
using System.Collections.Generic;
using System.Linq;//para fazer o comando where..

namespace Project.Repository.Persistence
{
    public class PerfilPersistence : GenericRepository<Perfil>
    {

        public int InserirPerfilMenu(Perfil perfil, List<int> idMenus)
        {
            foreach (var item in idMenus)
            {
                //utilizando um único context para realizar a gravação do perfil e menu..
                Menu m = new Menu();                
                m = _conn.Menu.Find(item);

                perfil.Menus.Add(m);
            }
            _conn.Perfil.Add(perfil);
            return _conn.SaveChanges();
        }

        public List<Perfil> ObterPorDescricao(string nome)
        {
            return _conn.Perfil.Where(p => p.Descricao.Contains(nome)).ToList();

        }

        public int AdicionarMenu(Perfil p, Menu m)
        {
            PerfilMenuPersistence pmp = new PerfilMenuPersistence();

            PerfilMenu pm = new PerfilMenu();
            pm.Perfil = p;
            pm.Menu = m;

            return pmp.Inserir(pm);           
        }
    }
}
