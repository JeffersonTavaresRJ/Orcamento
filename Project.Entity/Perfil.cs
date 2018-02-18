using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Entity
{
    public class Perfil
    {
        public int IdPerfil { get; set; }
        public string Descricao { get; set; }
        public List<Usuario> Usuarios { get; set; }
    }
}
