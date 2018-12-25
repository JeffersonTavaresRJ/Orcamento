using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Project.Web.Areas.AreaIndex.Models
{
    public class PerfilMenuViewModelConsulta
    {
        [Display(Name = "Perfil:")]
        public string NomePerfil { get; set; }

        public List<MenuViewModelSelecionaEdicao> Menus { get; set; }

        public PerfilMenuViewModelConsulta()
        {
            this.Menus = new List<MenuViewModelSelecionaEdicao>();
        }
    }
}