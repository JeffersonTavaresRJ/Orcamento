using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Project.Entity;

namespace Project.Web.Models.Usuario
{
    public class UsuarioViewModelCadastro
    {
        public string  Acao { get; set; }

        [RegularExpression("^[A-Z0-9]{4,4}$", 
            ErrorMessage = "O login do Usuário só pode ter 4 caracteres")]
        [Required(ErrorMessage ="Informe o Login")]
        [Display(Name ="Login:")]
        public string Id_Usuario { get; set; }

        [RegularExpression("^[A-Za-zÀ-Üà-ü\\s]{6,50}$",
           ErrorMessage = "Escreva o nome corretamente")]
        [Required(ErrorMessage = "Informe o Nome")]
        [Display(Name = "Nome:")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O perfil é obrigatório")]
        [Display(Name = "Perfil:")]
        public int Id_Perfil { get; set; }

        [RegularExpression("^[A-Za-z0-9]{6,10}$",
           ErrorMessage = "A senha deve possuir entre 6 a 10 caracteres, com letras e números")]
        [Required(ErrorMessage = "Informe a Senha")]
        [Display(Name = "Senha:")]
        public string Senha { get; set; }

        [Compare("Senha", ErrorMessage ="Senhas não conferem")]
        [Required(ErrorMessage = "Confirme a senha de acesso")]
        [Display(Name = "Confirme a Senha:")]
        public string ConfirmaSenha { get; set; }





    }
}