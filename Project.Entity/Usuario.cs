using System;

namespace Project.Entity
{
    public class Usuario
    {
        public string IdUsuario { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public virtual int IdPerfil { get; set; }
        public virtual Perfil Perfil { get; set; }

        private string status = "A";
        public  string Status
        {
            get {
                   return status;
            }
            set {
                if (!value.Equals(Convert.ToString((char)Project.Entity.Enuns.Status.A)) &&
                    !value.Equals(Convert.ToString((char)Project.Entity.Enuns.Status.I))
                   ){
                    throw new Exception("Os valores válidos são Ativo (A) e Inativo (I)");
                }
                else {
                    status = value;
                }
                
            }
        }
    }
}
