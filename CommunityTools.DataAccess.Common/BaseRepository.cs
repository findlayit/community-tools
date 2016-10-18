using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using AutoMapper;
using CommunityTools.Domain;

namespace CommunityTools.DataAccess.Common
{
    public class BaseRepository<T>: IBaseRepository<T> where T : class, IBaseEntity
    {
        protected readonly IUnitOfWork _unitOfWork;

        public BaseRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        ~BaseRepository()
        {
            //_unitOfWork.Committed -= _cacheManager.OnCommitChanges;
        }

        public virtual IEnumerable<T> FindAll()
        {

            var list = _unitOfWork.Set<T>().ToList();

            return list.OrderBy(x => x.Id);
        }

        public T FindById(int id)
        {
            var cached = FindAll();
            return cached.FirstOrDefault(x => x.Id == id && !x.IsDeleted);
        }

        public void Add(T entity)
        {
            _unitOfWork.Set<T>().Add(entity);
            _unitOfWork.Commit(updateCache: false);
        }

        public void Update(T entity)
        {
            var dbItem = _unitOfWork.Set<T>().FirstOrDefault(x => x.Id == entity.Id);

            if (dbItem == null)
            {
                throw new ArgumentException("Not an existing object");
            }

            //force retention of created at/by values
            //entity.CreatedAt = dbItem.CreatedAt;
            //entity.CreatedBy = dbItem.CreatedBy;

            //var existing = dbItem.DeepCopy();

            if (_unitOfWork.Entry(entity).State == EntityState.Detached)
            {
                var attachedEntry = _unitOfWork.Entry(dbItem);
                attachedEntry.CurrentValues.SetValues(entity);
            }
            else
                Mapper.Map(entity, dbItem);

        }

        /// <summary>
        /// Soft delete entity
        /// </summary>
        /// <param name="entity"></param>
        public void Remove(T entity)
        {
            entity.IsDeleted = true;

            _unitOfWork.Set<T>().Attach(entity);
        }

        /// <summary>
        /// Hard delete entity
        /// </summary>
        /// <param name="entity"></param>
        public void Delete(T entity)
        {
            _unitOfWork.Entry(entity).State = EntityState.Deleted;

        }

    }
}