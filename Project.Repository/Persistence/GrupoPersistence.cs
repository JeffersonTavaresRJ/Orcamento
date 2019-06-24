using System.Collections.Generic;
using Project.Entity;
using System.Linq;

namespace Project.Repository.Persistence
{
    public class GrupoPersistence : GenericRepository<Grupo>
    {
        public List<Grupo> ListarTodosGrupos()
        {
            return _conn.Grupo.Where(g => g.IdGrupo.Equals(null)).ToList();
        }

        public List<Grupo> ListarGruposNivel_1()
        {
            return _conn.Grupo.Where(g => g.IdGrupo == null).ToList();
        }

        public List<Grupo> ListarGruposNivel_2()
        {
            return _conn.Grupo.Where(g => g.IdGrupo > 0 ).ToList();
        }


    }
}
