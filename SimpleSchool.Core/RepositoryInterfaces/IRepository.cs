using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace SimpleSchool.Core.RepositoryInterfaces
{
    public interface IRepository<T>
    {
        //List<T> GetAll();
        //T GetById(int id);
        //List<T> GetByWhere(Expression<Func<T, bool>> filter);
        //void InsertOrUpdate(T t); //for single entity, not for the whole graph of the entity

        //List<T> GetGraphAll();
        //List<T> GetGraphByWhere(Expression<Func<T, bool>> filter);
        //List<T> GetAllIncluding(params Expression<Func<T, object>>[] includeProperties);
        //T GetGraphById(int id);
        //void InsertOrUpdateGraph(T t);

        List<T> GetAll();
        List<T> GetAllIncluding(params Expression<Func<T, object>>[] includeProperties);
        List<T> GetByWhere(Expression<Func<T, bool>> filter);
        T GetById(int id);
        void InsertOrUpdate(T t);
        void Delete(int id);
    }
}