﻿namespace BoletosBus_CleanModularApp.Common.Data.Repository
{
    public interface IBaseRepository<TEntity, TTypeId> where TEntity : class
    {
        void Save(TEntity entity);
        void Update(TEntity entity);
        void Remove(TEntity entity);
        List<TEntity> GetAll();
        TEntity? GetEntityById(TTypeId id);

    }
}
