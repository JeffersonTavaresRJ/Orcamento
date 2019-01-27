using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Entity
{
    public class Conta
    {
        public int Id { get; set; }
        public int IdGrupo { get; set; }
        public virtual Grupo Grupo { get; set; }
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
                   !value.Equals(Convert.ToString((char)Project.Entity.Enuns.Status.I)))
                {
                    throw new Exception("Os valores válidos são Ativo (A) e Inativo (I)");
                }
                else
                {
                    status = value;
                }
            }
        }
        private string tipoConta;
        public string TipoConta
        {
            get
            {
                return tipoConta;
            }
            set
            {
                if(!value.Equals(Convert.ToString((char)Project.Entity.Enuns.TipoConta.D)) &&
                   !value.Equals(Convert.ToString((char)Project.Entity.Enuns.TipoConta.R)))
                {
                    throw new Exception("Os valores válidos para o tipo de conta são Receita (R) e Despesa(D)");
                }
                else
                {
                    tipoConta = value;
                }
            }
        }

    }
}
