using System;
using System.Collections.Generic;

namespace Project.Entity
{
    public class Grupo
    {
        public int Id { get; set; }
        public int? IdGrupo { get; set; }
        public string Descricao { get; set; }
        private string status = "A";
        public string Status
        {
            get
            {
                return status;
            }
            set
            {
                if(!value.Equals(Convert.ToString((char)Project.Entity.Enuns.Status.A)) &&
                   !value.Equals(Convert.ToString((char)Project.Entity.Enuns.Status.I))
                   ){
                    throw new Exception("Os valores válidos são Ativo (A) e Inativo (I)");
                }
                else
                {
                    status = value;
                }

            }
        }

        public virtual ICollection<Grupo> Grupos { get; set; }
        public virtual ICollection<ItemConta> ItemContas { get; set; }
    }
}
