using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Project.Web.Areas.AreaIndex.Models
{
    public class PerfilViewModelInclusao
    {
        [Display(Name ="Perfil:")]
        [Required(ErrorMessage ="A descrição deve ser informada")]
        [MaxLength(50,ErrorMessage ="A descrição deve ter no máximo 50 caracteres")]
        public string Descricao { get; set; }
    }
}