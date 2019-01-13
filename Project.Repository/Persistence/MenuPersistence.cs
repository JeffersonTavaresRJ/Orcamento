using Project.Entity;
using System.Collections.Generic;
//para uso do método ToList.. 
using System.Linq;

namespace Project.Repository.Persistence
{
    public class MenuPersistence : GenericRepository<Menu>
    {

        public Menu ObterMenuPorId(int? _Id)
        {
            return _conn.Menu.Find(_Id);

        }

        public IEnumerable<Menu> ListarMenu(Menu busca, string ordenar)
        {
            IEnumerable<Menu> lista;
            try
            {
                lista = (from m in _conn.Menu
                         join sm in _conn.Menu on m.Id equals sm.IdMenu                       
                         select sm).ToList();


                lista = BuscarMenu(lista, busca);
                lista = OrdernarMenu(lista, ordenar);
            }
            catch (System.Exception)
            {

                throw;
            }

            return lista;
        }

        private IEnumerable<Menu> BuscarMenu(IEnumerable<Menu> menu, Menu busca)
        {
            if (!string.IsNullOrEmpty(busca.Nome))
            {

                menu = menu.Where(m => m.Nome.ToLower().StartsWith(busca.Nome.ToLower()) ||
                                       m.Nome.ToLower().EndsWith(busca.Nome.ToLower()));
            }

            if (busca.Perfis != null)
            {
                foreach (var item in busca.Perfis)
                {
                    menu = menu.Where(m => m.Perfis.Equals(item));
                }

            }

            if (!string.IsNullOrEmpty(busca.Status))
            {
                menu = menu.Where(m => m.Status.Equals(busca.Status));
            }

            if (busca.Id == 0)
            {
                menu = menu.Where(m => m.Id > 0);
            }
            else
            {
                menu = menu.Where(m => m.Id.Equals(busca.Id));
            }

            if (busca.IdMenu == 0 || busca.IdMenu == null)
            {
                menu = menu.Where(m => m.IdMenu > 0);
            }
            else
            {
                menu = menu.Where(m => m.IdMenu.Equals(busca.IdMenu));
            }

            return menu;
        }

        private IEnumerable<Menu> OrdernarMenu(IEnumerable<Menu> menu, string ordenar)
        {
            switch (ordenar.ToLower())
            {
                default:
                    menu = menu.OrderBy(m => m.Perfis.Count()).ThenBy(m => m.Menus.Count());
                    break;
                case "nome":
                    menu = menu.OrderBy(m => m.Nome).ThenBy(m => m.Nome.Length);
                    break;
                case "perfis":
                    menu = menu.OrderBy(m => m.Perfis);
                    break;
                case "status":
                    menu = menu.OrderBy(m => m.Status);
                    break;
            }
            return menu;
        }

        public List<Menu> ListarTableMenus()
        {
            List<Menu> lista = new List<Menu>();
            IEnumerable<Menu> menus = this.ListarMenu(new Menu() { IdMenu = 0 }, "nome");

            foreach (var item in menus)
            {
                if (item.IdMenu > 0)
                {
                    Menu menu = new Menu();
                    menu.Id = item.Id;
                    menu.IdMenu = item.IdMenu;
                    menu.Status = item.Status;

                    string descricaoMenu = null;
                    int? IdMenuAnt = item.IdMenu;

                    while (IdMenuAnt > 0)
                    {
                        if (descricaoMenu == null)
                        {
                            descricaoMenu = item.Nome;
                        }
                        Menu m = this.ObterMenuPorId(IdMenuAnt);
                        descricaoMenu = m.Nome + " >> " + descricaoMenu;
                        IdMenuAnt = m.IdMenu;
                    }
                    menu.Nome = descricaoMenu;
                    lista.Add(menu);
                }
            }

            return lista;
        }

    }
}
