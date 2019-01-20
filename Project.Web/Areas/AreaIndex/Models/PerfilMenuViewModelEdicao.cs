using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Web.Areas.AreaIndex.Models
{
    public class PerfilMenuViewModelEdicao
    {
        public int IdPerfil { get; set; }
        public List<int> Menus { get; set; }
    }
}