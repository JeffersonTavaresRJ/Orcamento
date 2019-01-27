using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Entity
{
    public class FormaPagamento
    {
        public int Id { get; set; }
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
        
    }
}
