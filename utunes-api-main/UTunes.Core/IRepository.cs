using System;
namespace UTunes.Core
{
    public interface IRepository<TEntity>
    where TEntity : class
    {
        Task<TEntity> AddAsync(TEntity entity);

        TEntity Update(TEntity entity);

        Task<IReadOnlyList<TEntity>> AllAsync();

        IReadOnlyList<TEntity> Filter(Func<TEntity, bool> predicate);

        TEntity? GetById(int id);

        Task<int> CommitAsync();

        int Commit();
    }
}

