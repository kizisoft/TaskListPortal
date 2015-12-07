namespace TaskListPortal.Common.Repository
{
    using System;
    using System.Linq;

    public interface IDbRepository<T> : IDisposable
    {
        void Add(T entity);

        IQueryable<T> All();

        IQueryable<T> AllWithDeleted();

        T GetById(string id);

        void Update(T entity);

        void Delete(T entity);

        int SaveChanges();
    }
}