using System.ComponentModel.DataAnnotations;
using Project.Utility.UtilValidator;

namespace Project.Web.Models.Login
{
    public class RedefinirSenhaViewModel
    {
        public string Login { get; set; }

        public string Nome { get; set; }

        [Display(Name = "Senha: ")]
        [SenhaValidator(ErrorMessage = "A senha deve possuir entre 6 a 10 caracteres, com letras e números. A senha default é inválida")]
        [Required(ErrorMessage = "Informe a Senha")]
        public string Senha { get; set; }

        [Display(Name = "Confirme a senha: ")]
        [Compare("Senha", ErrorMessage = "Senhas não conferem")]
        [Required(ErrorMessage = "Confirme a senha de acesso")]
        public string ConfirmarSenha { get; set; }
    }
}