using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;
using Project.Repository.Configurations;

namespace Project.Repository.Persistence
{
    public abstract class GenericRepository<TEntity>
        where TEntity:class
    {
        public virtual int Inserir(TEntity obj)
        {
            using(DataContextOrcamento conn = new DataContextOrcamento())
            {
                conn.Entry(obj).State = EntityState.Added;
                return conn.SaveChanges();
            }
        }

        public virtual int Atualizar(TEntity obj)
        {
            using(DataContextOrcamento conn = new DataContextOrcamento())
            {
                conn.Entry(obj).State = EntityState.Modified;
                return conn.SaveChanges();
            }
        }

        public virtual int Excluir(TEntity obj)
        {
            using (DataContextOrcamento conn = new DataContextOrcamento())
            {
                conn.Entry(obj).State = EntityState.Deleted;
                return conn.SaveChanges();
            }
        }

        public virtual List<TEntity> ListarTodos()
        {
            using (DataContextOrcamento conn = new DataContextOrcamento())
            {
                conn.Database.Log = Console.WriteLine;
                return conn.Set<TEntity>().ToList();
            }
                

        }

        public virtual TEntity ObterPorId(int _Id)
        {
            using(DataContextOrcamento conn = new DataContextOrcamento())
            {
                return conn.Set<TEntity>().Find(_Id);
            }
        }

    }
}
