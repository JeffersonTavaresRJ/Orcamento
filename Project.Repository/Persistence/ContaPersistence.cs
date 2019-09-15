using Project.Entity;
using System.Collections.Generic;
using System.Linq;

namespace Project.Repository.Persistence
{
    public class ContaPersistence : GenericRepository<Conta>
    {
        public List<Conta> ObterPorDescricao(string _descricao)
        {
            return _conn.Conta.Where(c => c.Descricao.ToUpper().Contains(_descricao.ToUpper())).ToList();
        }
    }
}
