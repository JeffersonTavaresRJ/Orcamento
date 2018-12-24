using Project.Utility.UtilValidator;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
//using PagedList.Mvc;

namespace Project.Web.Areas.AreaIndex.Models
{
    public class PerfilMenuViewModelInclusao
    {
        [Display(Name = "Perfil:")]
        [Required(ErrorMessage = "O nome do perfil deve ser informado")]
        [MaxLength(50, ErrorMessage = "O nome do perfil deve ter no máximo 50 caracteres")]
        [DescricaoPerfilValidador(ErrorMessage = "O nome do perfil já existe com este nome")]
        public string NomePerfil { get; set; }

       // [Required(ErrorMessage = "Um item de menu deve ser informado")]
       // public PagedList.IPagedList<MenuViewModelSelecionaEdicao> Menus { get; set; }
        public List<MenuViewModelSelecionaEdicao> Menus { get; set; }

        public PerfilMenuViewModelInclusao()
        {
            this.Menus = new List<MenuViewModelSelecionaEdicao>();
        }

        public IEnumerable<int> getSelectedIds()
        {
            //retorna os Ids selecionados
            return (from p in this.Menus where p.Selecionado select p.Id).ToList();
        }
    }
}