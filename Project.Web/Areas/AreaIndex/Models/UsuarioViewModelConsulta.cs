using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Project.Entity;

namespace Project.Web.Areas.AreaIndex.Models
{
    public class UsuarioViewModelConsulta
    {
        public string IdUsuario { get; set; }
        public string Nome { get; set; }
        public string Perfil { get; set; }
        public string Status { get; set; }
    }
}