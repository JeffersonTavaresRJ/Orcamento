using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Entity
{
    public class Perfil
    {
        //mapeamento muito para muitos no entity framework..
        public Perfil()
        {
            PerfilMenu = new HashSet<PerfilMenu>();
        }

        public virtual int Id { get; set; }
        public string Descricao { get; set; }

        //mapeamento muito para muitos no entity framework..
        public virtual List<Usuario> Usuarios { get; set; }
        public virtual ICollection<PerfilMenu> PerfilMenu { get; set; }
    }
}
