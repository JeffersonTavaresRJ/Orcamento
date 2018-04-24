using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Project.Entity.Enuns;

namespace Project.Web.Areas.AreaIndex.Models
{
    public class UsuarioViewModelFiltro
    {
        [Display(Name ="Login ou Nome:")]
        public string Busca { get; set; }
        [Display(Name ="Perfil:")]
        public int Id_Perfil { get; set; }
        [Display(Name ="Status:")]
        public string IdStatus { get; set; }
    }
}