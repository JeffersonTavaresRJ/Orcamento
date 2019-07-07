using System.ComponentModel.DataAnnotations;

namespace Project.Web.Areas.AreaIndex.Models
{
    public class GrupoViewModel
    {
        [Display(Name ="Grupo Principal:")]
        // o ponto de interrogação "?" permite que o dropdown não seja obrigatório..
        public int? Id_Grupo { get; set; }

        [Display(Name ="Descrição:")]
        [Required(ErrorMessage ="A Descrição do grupo é obrigatória")]
        public string Descricao { get; set; }
    }
}