using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Entity
{
    public class Perfil
    {

        public virtual int Id { get; set; }
        public string Descricao { get; set; }

        //mapeamento muito para muitos no entity framework..
        public virtual List<Usuario> Usuarios { get; set; }
        public virtual ICollection<Menu> Menus { get; set; }

        public Perfil()
        {
            Menus = new List<Menu>();
        }
        
    }
}
