using System.ComponentModel.DataAnnotations;


namespace Project.Web.Areas.AreaIndex.Models
{
    public class UsuarioViewModelEdicao
    {

        [RegularExpression("^[A-Z0-9]{4,4}$",
            ErrorMessage = "O login do Usuário só pode ter 4 caracteres")]
        [Required(ErrorMessage = "Informe o Login")]
        [Display(Name = "Login:")]
        public string Id_Usuario { get; set; }

        [RegularExpression("^[A-Za-zÀ-Üà-ü\\s]{6,50}$",
           ErrorMessage = "Escreva o nome corretamente")]
        [Required(ErrorMessage = "Informe o Nome")]
        [Display(Name = "Nome:")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O perfil é obrigatório")]
        [Display(Name = "Perfil:")]
        public int Id_Perfil { get; set; }

        [Display(Name = "redefinir senha")]
        public bool RedefinirSenha { get; set; }

    }
}