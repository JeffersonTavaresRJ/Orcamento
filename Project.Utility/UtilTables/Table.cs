using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Utility.UtilTables
{
    public class ListaPaginada<T>
    {
        public int TotalItens { get; private set; }
        public int ItensPorPagina { get; private set; }
        public int PaginaAtual { get; private set; }

        public int TotalPaginas
        {
            get { return TotalItens / ItensPorPagina; }
        }

        public List<T> Itens { get; private set; }

        public ListaPaginada(List<T> itens, int totalItens, int itensPorPagina, int paginaAtual)
        {
            this.Itens = itens;
            this.TotalItens = totalItens;
            this.ItensPorPagina = itensPorPagina;
            this.PaginaAtual = paginaAtual;
        }
    }
}
