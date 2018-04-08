using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Project.Utility.UtilComboBox
{
    public class Combobox
    {

        /// <summary>
        /// Retorna uma lista com os valores de um determinado enumerador.
        /// </summary>
        /// <param name="tipo">Enumerador que terá os valores listados.</param>
        /// <returns>Lista com os valores do Enumerador.</returns>
        public static IList Listar(Type tipo)
        {
            ArrayList lista = new ArrayList();
            lista.Add(new KeyValuePair<string, string>("-1", "--Selecione--"));

            if (tipo != null)
            {
                Array enumValores = Enum.GetValues(tipo);
                foreach (Enum valor in enumValores)
                {
                    //valor=Id
                    //ObterDescricao=Descrição
                    lista.Add(new KeyValuePair<Enum, string>(valor, ObterDescricao(valor)));
                }
            }

            return lista;
        }



        /// <summary>
        /// Obtém a descrição de um determinado Enumerador.
        /// </summary>
        /// <param name="valor">Enumerador que terá a descrição obtida.</param>
        /// <returns>String com a descrição do Enumerador.</returns>
        public static string ObterDescricao(Enum valor)
        {
            FieldInfo fieldInfo = valor.GetType().GetField(valor.ToString());

            DescriptionAttribute[] atributos = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);

            return atributos.Length > 0 ? atributos[0].Description ?? "Nulo" : valor.ToString();
        }
    }
}
