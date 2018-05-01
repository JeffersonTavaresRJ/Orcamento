using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Reflection;

namespace Project.Utility.UtilTables
{
    public class DataTableHelper<T>
    {
        private IList<T> listaDados;
        string echo = "";
        int iColumns = 0;
        int iDisplayStart = 0;
        int iDisplayLength = 0;
        IList<string> columnNames = new List<string>();
        Dictionary<string, string> columnNamesOrder = new Dictionary<string, string>();
        string iSortingCols = "";
        int regExibir = 0;
        int startExibir = 0;
        int totalRegistros = 0;

        public DataTableHelper(IList<T> data, int totalRegistrosSemFiltro)
        {
            listaDados = data;
            totalRegistros = totalRegistrosSemFiltro;
        }

        public Func<T, TipoRetorno> GetFuncao<TipoRetorno>(string propertyName)
        {
            PropertyInfo propert = typeof(T).GetProperty(propertyName);

            Func<T, TipoRetorno> funcao = (Func<T, TipoRetorno>)
                     Delegate.CreateDelegate(typeof(Func<T, TipoRetorno>),
                     null, propert.GetGetMethod());

            return funcao;
        }

        public object getDataTablesObject(HttpRequestBase request)
        {
            echo = request.Params["sEcho"].ToString();
            iColumns = int.Parse(request.Params["iColumns"].ToString());
            iDisplayStart = int.Parse(request.Params["iDisplayStart"].ToString());
            iDisplayLength = int.Parse(request.Params["iDisplayLength"].ToString());
            iSortingCols = request.Params["iSortingCols"].ToString();

            regExibir = iDisplayLength;
            startExibir = iDisplayStart;

            for (int i = 0; i < iColumns; i++)
            {
                string nomeColuna = request.Params["mDataProp_" + i.ToString()].ToString();
                columnNames.Add(nomeColuna);
            }

            for (int i = 0; i < iColumns; i++)
            {
                if (request.Params["iSortCol_" + i.ToString()] != null)
                {
                    int idxColuna = int.Parse(request.Params["iSortCol_" + i.ToString()]);

                    string nomeColuna = columnNames[idxColuna];
                    string orderDirection = request.Params["sSortDir_" + i.ToString()].ToString();

                    columnNamesOrder.Add(nomeColuna, orderDirection);
                }

            }

            if (iDisplayStart > listaDados.Count)
            {
                startExibir = 0;
            }

            if (iDisplayStart + iDisplayLength > listaDados.Count)
            {
                regExibir = listaDados.Count - startExibir;
            }


            IOrderedEnumerable<T> listaPartialSort = null;

            foreach (string columnName in columnNamesOrder.Keys)
            {
                PropertyInfo propert = typeof(T).GetProperty(columnName);

                if (columnNamesOrder[columnName] == "asc")
                {
                    if (listaPartialSort == null)
                    {
                        if (propert.PropertyType == typeof(string))
                        {
                            listaPartialSort =
                                    listaDados.OrderBy(GetFuncao<string>
                                    (columnName));
                        }
                        else
                        {
                            listaPartialSort =
                                     listaDados.OrderBy(GetFuncao<int>
                                     (columnName));
                        }
                    }
                    else
                    {
                        if (propert.PropertyType == typeof(String))
                        {
                            listaPartialSort =
                                     listaPartialSort.ThenBy
                                     (GetFuncao<string>
                                     (columnName));
                        }
                        else
                        {
                            listaPartialSort =
                                     listaPartialSort.ThenBy
                                     (GetFuncao<int>
                                     (columnName));
                        }
                    }
                }
                else
                {
                    if (listaPartialSort == null)
                    {
                        if (propert.PropertyType == typeof(string))
                        {
                            listaPartialSort =
                                    listaDados.OrderByDescending(GetFuncao<string>
                                    (columnName));
                        }
                        else
                        {
                            listaPartialSort =
                                     listaDados.OrderByDescending(GetFuncao<int>
                                     (columnName));
                        }
                    }
                    else
                    {
                        if (propert.PropertyType == typeof(String))
                        {
                            listaPartialSort =
                                     listaPartialSort.ThenByDescending
                                     (GetFuncao<string>
                                     (columnName));
                        }
                        else
                        {
                            listaPartialSort =
                                     listaPartialSort.ThenByDescending
                                     (GetFuncao<int>
                                     (columnName));
                        }
                    }
                }
            }

            IList<T> listaDadosSorted = listaPartialSort.ToList<T>();

            var objeto = new
            {
                iTotalRecords = totalRegistros,
                iTotalDisplayRecords = listaDados.Count,
                sEcho = echo,
                aaData = listaDadosSorted.ToList<T>().GetRange(startExibir, regExibir)
            };

            return objeto;

        }


    }

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
