using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Project.Utility.UtilValidator;
using Project.Entity;

namespace Project.Web.Areas.AreaIndex.Models
{
    public class PerfilViewModelInclusao
    {
        [Display(Name ="Perfil:")]
        [Required(ErrorMessage ="A descrição deve ser informada")]
        [MaxLength(50,ErrorMessage ="A descrição deve ter no máximo 50 caracteres")]
        [DescricaoPerfilValidador(ErrorMessage ="A descrição já existe")]
        public string Descricao { get; set; }

        public List<MenuViewModelConsulta> Menus { get; set; }
    }
}