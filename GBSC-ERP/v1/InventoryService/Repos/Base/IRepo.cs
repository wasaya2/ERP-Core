using InventoryService.Repos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace InventoryService.Repos.Base
{
    public interface IRepo<T> : IFeaturePermissions
    {
        int Count { get; }

        bool HasChanges { get; }

        T Find(long? id);

        T GetFirst(Func<T, bool> where, params Expression<Func<T, object>>[] navigationProperties);

        IEnumerable<T> GetAll(params Expression<Func<T, object>>[] navigationProperties);

        IEnumerable<T> GetList(Func<T, bool> where, params Expression<Func<T, object>>[] navigationProperties);

        T GetFirst();

        T GetLast();

        T GetFirst(Func<T, bool> where);

        IEnumerable<T> GetList(Func<T, bool> where);

        IEnumerable<T> GetAll();

        IEnumerable<T> GetRange(int skip, int take);

        int Add(T entity, bool persist = true);

        int AddRange(IEnumerable<T> entities, bool persist = true);

        int Update(T entity, bool persist = true);

        int UpdateRange(IEnumerable<T> entities, bool persist = true);

        int Delete(T entity, bool persist = true);

        int DeleteRange(IEnumerable<T> entities, bool persist = true);

        //int Delete(int id, byte[] timeStamp, bool persist = true);

        int SaveChanges();
    }
}
