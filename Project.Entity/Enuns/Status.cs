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
        Ativo ='A',
        [Description("Inativo")]
        Inativo ='I'
    }
}
