using Project.Entity;

namespace Project.Repository.Persistence
{
    public class PerfilPersistence : GenericRepository<Perfil>
    {
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
