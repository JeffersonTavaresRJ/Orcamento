using System.ComponentModel.DataAnnotations;


namespace Project.Web.Areas.AreaIndex.Models
{
    public class GrupoViewModelInclusao
    {
        [Display(Name ="Grupo Principal:")]
        public int Id_Grupo { get; set; }

        [Display(Name ="Descrição:")]
        [Required(ErrorMessage ="A Descrição do grupo é obrigatória")]
        public string Descricao { get; set; }
    }
}