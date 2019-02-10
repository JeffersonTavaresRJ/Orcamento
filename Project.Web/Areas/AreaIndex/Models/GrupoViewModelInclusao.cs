using System.ComponentModel.DataAnnotations;

namespace Project.Web.Areas.AreaIndex.Models
{
    public class GrupoViewModelInclusao
    {

        [Required(ErrorMessage ="O nome é campo obrigatório")]
        [Display(Name ="Nome do Grupo")]
        public string NomeGrupo { get; set; }
    }
}