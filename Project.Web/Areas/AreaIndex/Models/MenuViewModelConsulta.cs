using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Project.Web.Areas.AreaIndex.Models
{
    public class MenuViewModelConsulta
    {
        [Display(Name = "Id")]
        public int Id { get; set; }
        [Display(Name ="IdMenu")]
        public int? IdMenu { get; set; }
        [Display(Name ="Item de Menu")]
        public string Nome { get; set; }
        [Display(Name = "Selecionar")]
        public bool Selecao{ get; set; }
    }
}