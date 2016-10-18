using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace CommunityTools.DataAccess.Common
{
    public interface IUnitOfWork
    {
        DbSet<T> Set<T>() where T : class;
        DbEntityEntry Entry<T>(T entity) where T : class;
        void Commit(bool updateCache = true);
        event EventHandler Committed;
        void Detach(object customerEntity);
        void Detach(IEnumerable<object> entities);

    }
}