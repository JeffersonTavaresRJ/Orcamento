
using System;
using System.Collections.Generic;

namespace Project.Entity
{
    public class Menu
    {

        public int Id { get; set; }

        //marcando com o ponto de interrogação para aceitar valor nulo..
        public int? IdMenu { get; set; }

        public string Nome { get; set; }
        public string Path { get; set; }
        private string status = "A";
        public string Status
        {
            get
            {
                return status;
            }
            set
            {
                if (!value.Equals(Convert.ToString((char)Project.Entity.Enuns.Status.A)) &&
                    !value.Equals(Convert.ToString((char)Project.Entity.Enuns.Status.I))
                   )
                {
                    throw new Exception("Os valores válidos são Ativo (A) e Inativo (I)");
                }
                else
                {
                    status = value;
                }

            }
        }

        //mapeamento muito para muitos no entity framework..
        public virtual ICollection<Menu> Menus { get; set; }
        public virtual ICollection<Perfil> Perfis { get; set; }


    }
}
