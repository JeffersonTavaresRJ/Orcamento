using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Entity.Enuns
{
    public static class ExtensionEnum
    {

        public static Status status;

        public static T ObterAtributoDoTipo<T>(this Enum valorEnum) where T : System.Attribute
        {
            var type = valorEnum.GetType();
            var menInfo = type.GetMember(valorEnum.ToString());
            var atributtes = menInfo[0].GetCustomAttributes(typeof(T), false);
            return (atributtes.Length > 0) ? (T)atributtes[0] : null;
        }

        public static string ObterDescricao(this Enum valorEnum)
        {
            return valorEnum.ObterAtributoDoTipo<DescriptionAttribute>().Description;
        }
    }
}
