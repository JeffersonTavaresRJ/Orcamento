using Project.Entity;
using System.Collections.Generic;
//para uso do método include e where nas classes do entity..
using System.Data.Entity;

//para uso do método ToList.. 
using System.Linq;

namespace Project.Repository.Persistence
{
    public class MenuPersistence : GenericRepository<Menu>
    {
        //public List<Menu> ObterItensMenus(Perfil perfil)
        //{
        //    List<Menu> lista = new List<Menu>();

        //    /*lista =*/ _conn.Menu
        //                    .Where(m=>m.Perfis.Contains(perfil))
        //                    .ToList();
        //    return lista;
           

        //}

    }
}
