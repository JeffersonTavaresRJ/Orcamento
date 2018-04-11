﻿using System;
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
        private DataContextOrcamento _conn { get; set; }

        public GenericRepository()
        {
            _conn = new DataContextOrcamento();
        }    


        public virtual int Inserir(TEntity obj)
        {
            //using (DataContextOrcamento conn = new DataContextOrcamento())
            //{
                _conn.Entry(obj).State = EntityState.Added;
                return _conn.SaveChanges();
            //}
        }

        public virtual int Atualizar(TEntity obj)
        {
            //using(DataContextOrcamento conn = new DataContextOrcamento())
            //{
                _conn.Entry(obj).State = EntityState.Modified;
                return _conn.SaveChanges();
            //}
        }

        public virtual int Excluir(TEntity obj)
        {
            //using (DataContextOrcamento conn = new DataContextOrcamento())
            //{
                _conn.Entry(obj).State = EntityState.Deleted;
                return _conn.SaveChanges();
            //}
        }

        public virtual List<TEntity> ListarTodos()
        {
            //using (DataContextOrcamento conn = new DataContextOrcamento())
            //{
                return _conn.Set<TEntity>().ToList();
            //}
                

        }

        public virtual TEntity ObterPorId(int _Id)
        {
            //using(DataContextOrcamento conn = new DataContextOrcamento())
            //{
                return _conn.Set<TEntity>().Find(_Id);
            //}
        }

    }
}
