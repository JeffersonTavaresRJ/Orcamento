using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Web.Areas.AreaIndex.Models
{
    public class FormaPagamentoViewModelConsulta
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public string Status { get; set; }
        public string DescricaoStatus { get; set; }
    }
}