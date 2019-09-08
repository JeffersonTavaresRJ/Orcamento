using Project.Entity;
using System.Collections.Generic;
using System.Linq;

namespace Project.Repository.Persistence
{
    public class FormaPagamentoPersistence : GenericRepository<FormaPagamento>
    {
        public List<FormaPagamento> ObterPorDescricao(string _descricao)
        {
            return _conn.FormaPagamento.Where(f => f.Descricao.ToUpper().Trim().Contains(_descricao.ToUpper().Trim())).ToList();
        }
    }
}
