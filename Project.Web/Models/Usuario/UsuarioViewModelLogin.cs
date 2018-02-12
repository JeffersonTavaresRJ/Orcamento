using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Project.Web.Models.Usuario
{
    public class UsuarioViewModelLogin
    {
        [Display(Name ="Login:")]
        [Required(ErrorMessage ="Informe o Login")]
        public string Login { get; set; }

        [Display(Name = "Senha:")]
        [Required(ErrorMessage = "Informe a Senha")]
        public string Senha { get; set; }
    }
}