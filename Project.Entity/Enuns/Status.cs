using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Entity.Enuns
{
    public enum Status
    {
        [Description("Ativo")]
        A = 'A',
        [Description("Inativo")]
        I = 'I'
    }


}
