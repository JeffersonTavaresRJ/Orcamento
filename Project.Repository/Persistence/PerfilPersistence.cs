using Project.Entity;
using System.Collections.Generic;
using System.Linq;//para fazer o comando where..

namespace Project.Repository.Persistence
{
    public class PerfilPersistence : GenericRepository<Perfil>
    {

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
