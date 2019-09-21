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

        public IEnumerable<Grupo> ListarGruposNivel_2(int id)
        {
            IEnumerable<Grupo> lista;
            lista = (from g in _conn.Grupo
                     join sg in _conn.Grupo on g.Id equals sg.IdGrupo
                     select sg)
                     .Where(sg => sg.IdGrupo==id).ToList();

            return lista;
        }
    }
}
