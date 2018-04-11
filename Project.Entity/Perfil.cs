using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Entity
{
    public class Perfil
    {
        public virtual int IdPerfil { get; set; }
        public string Descricao { get; set; }
        public virtual List<Usuario> Usuarios { get; set; }
    }
}
