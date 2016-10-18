using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace CommunityTools.DataAccess.Common
{
    public class UnitOfWork : IUnitOfWork
    {
        readonly DbContext _context;
        private bool _isDisposed;
        public event EventHandler Committed;
        public void Detach(object entity)
        {
            if (entity != null)
            {
                ((IObjectContextAdapter)_context).ObjectContext.Detach(entity);
            }
        }

        public void Detach(IEnumerable<object> entities)
        {
            foreach (var o in entities)
            {
                Detach(o);
            }
        }

        public UnitOfWork(DbContext context)
        {
            _context = context;
        }

        public DbSet<T> Set<T>() where T : class
        {
            return _context.Set<T>();
        }

        public DbEntityEntry Entry<T>(T entity) where T : class
        {
            return _context.Entry(entity);
        }

        public void Commit(bool updateCache = true)
        {
            if (updateCache) OnCommited(null);

            bool saveFailed;
            do
            {
                saveFailed = false;
                try
                {
                    _context.ChangeTracker.DetectChanges();
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    saveFailed = true;
                    var entry = ex.Entries.Single();
                    if (entry.State == EntityState.Deleted)
                        //When EF deletes an item its state is set to Detached
                        //http://msdn.microsoft.com/en-us/data/jj592676.aspx
                        entry.State = EntityState.Detached;
                    else
                        entry.OriginalValues.SetValues(entry.GetDatabaseValues());

                }
            } while (saveFailed);

        }

        public void Dispose()
        {
            if (_isDisposed)
                return;

            _isDisposed = true;
            _context.Dispose();
        }

        protected virtual void OnCommited(EventArgs e)
        {
            if (Committed != null)
                Committed(this, e);
        }


    }
}