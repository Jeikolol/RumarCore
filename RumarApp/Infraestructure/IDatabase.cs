using Core.Entities;
using Microsoft.EntityFrameworkCore;
using RumarApp.Models;
using RumarApp.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace RumarApp.Infraestructure
{
    public interface IDatabase : IDisposable
    {
        /// Transform UtcDateTime To UserTimeZone
        /// </summary>
        DateTime TransformUtcDateToUserTimeZone(DateTime date);
        DateTime? TransformUtcDateToUserTimeZone(DateTime? date);

        /// <summary>
        /// Transform DateTime Properties from UtcDateTime in a List To UserTimeZone
        /// </summary>
        //IEnumerable<T> SetUserTimeZoneToCollection<T>(List<T> listToUpdate,
        //    params Expression<Func<T, object>>[] propertiesToUtc);
        IEnumerable<T> SetUserTimeZoneToDatePropertiesCollection<T, T2>(List<T> listToUpdate,
            params Expression<Func<T, T2>>[] propertiesToUtc);

        IEnumerable<T> SetUserTimeZoneToNullableDatePropertiesCollection<T, T2>(List<T> listToUpdate,
            params Expression<Func<T, T2>>[] propertiesToUtc);


        /// <summary>
        /// Get system table from a system entity.
        /// </summary>
        /// <typeparam name="TEntity">System Entity</typeparam>
        /// <returns>IDbSet of TEntity</returns>
        DbSet<TEntity> Table<TEntity>() where TEntity : Entity;

        /// <summary>
        /// Add an object to Table graph of specific entity.
        /// </summary>
        /// <typeparam name="TEntity">System Entity</typeparam>
        /// <param name="entity">Object to be add</param>
        /// <returns>Added Object</returns>
        void Insert<TEntity>(TEntity entity) where TEntity : Entity;

        /// <summary>
        /// Add an object or update to Table graph of specific entity.
        /// if id property is zero (0) row is added else is updated
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entity"></param>
        void InsertOrUpdate<TEntity>(TEntity entity) where TEntity : Entity;

        /// <summary>
        /// Mark an object as updated in the Table graph of specific entity.
        /// </summary>
        /// <typeparam name="TEntity">System Entity</typeparam>
        /// <param name="entity">Object to be update</param>
        /// <returns>Updated object</returns>
        void Update<TEntity>(TEntity entity) where TEntity : Entity;

        void Delete<TEntity>(TEntity entity) where TEntity : Entity;

        /// <summary>
        /// Mark an SoftDeletableEntity as deleted in the Table graph.
        /// </summary>
        /// <typeparam name="TEntity">Soft Deletable System Entity</typeparam>
        /// <param name="entity">Object to be mark as deleted</param>
        /// <param name="softDeleteParameter"></param>
        /// <returns>Updated Object</returns>
        void SoftDelete<TEntity>(TEntity entity, SoftDeletableEntityParameter softDeleteParameter) where TEntity : Entity, ISoftDeletableEntity;

        /// <summary>
        /// Get an object by it's Id
        /// </summary>
        /// <typeparam name="TEntity">System Entity</typeparam>
        /// <param name="id">TEntity Id</param>
        /// <param name="include">Array of properties to include</param>
        /// <returns>TEntity Object</returns>
        Task<TEntity> GetSingleByIdAsync<TEntity>(int id, params Expression<Func<TEntity, object>>[] include) where TEntity : Entity;

        /// <summary>
        /// Get an not deleted entity by Id
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="id"></param>
        /// <param name="include"></param>
        /// <returns></returns>
        Task<TEntity> GetNotDeletedEntityByIdAsync<TEntity>(int id, params Expression<Func<TEntity, object>>[] include)
            where TEntity : Entity, ISoftDeletableEntity;


        /// <summary>
        /// Get single an not deleted entity
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="id"></param>
        /// <param name="query"></param>
        /// <param name="include"></param>
        /// <returns></returns>
        Task<TEntity> GetNotDeletedEntityByIdAsync<TEntity>(int id, Expression<Func<TEntity, bool>> query, params Expression<Func<TEntity, object>>[] include)
            where TEntity : Entity, ISoftDeletableEntity;

        /// <summary>
        /// Get an not deleted entity by Id
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="query"></param>
        /// <param name="include"></param>
        /// <returns></returns>
        Task<TEntity> GetSingleNotDeletedEntityAsync<TEntity>(Expression<Func<TEntity, bool>> query, params Expression<Func<TEntity, object>>[] include)
            where TEntity : Entity, ISoftDeletableEntity;

        /// <summary>
        /// Get an object by filter
        /// </summary>
        /// <typeparam name="TEntity">System Entity</typeparam>
        /// <param name="query">The predicate to be execute against Database</param>
        /// <param name="include">Array of properties to include</param>
        /// <returns>TEntity object</returns>
        Task<TEntity> GetSingleAsync<TEntity>(Expression<Func<TEntity, bool>> query, params Expression<Func<TEntity, object>>[] include) where TEntity : Entity;

        /// <summary>
        /// Get a Collection of TEntity
        /// </summary>
        /// <typeparam name="TEntity">System Entity</typeparam>        
        /// <param name="include">Array of properties to include.</param>
        /// <returns>A materialized collection of TEntity.</returns>
        Task<List<TEntity>> GetCollectionAsync<TEntity>(params Expression<Func<TEntity, object>>[] include) where TEntity : Entity;


        /// <summary>
        /// Get a Collection of TEntity by a filter.
        /// </summary>
        /// <typeparam name="TEntity">System Entity</typeparam>
        /// <param name="query">The predicate to be execute against Database.</param>
        /// <param name="include">Array of properties to include.</param>
        /// <returns>A materialized collection of TEntity.</returns>
        Task<List<TEntity>> GetCollectionAsync<TEntity>(Expression<Func<TEntity, bool>> query, params Expression<Func<TEntity, object>>[] include) where TEntity : Entity;

        /// <summary>
        /// Get a Collection of Not Deleted TEntity.
        /// </summary>
        /// <typeparam name="TEntity">System SoftDeletableEntity</typeparam>
        /// <param name="include">Array of properties to include.</param>
        /// <returns>A materialized collection of TEntity.</returns>
        Task<List<TEntity>> GetNotDeletedCollectionAsync<TEntity>(params Expression<Func<TEntity, object>>[] include)
            where TEntity : Entity, ISoftDeletableEntity;

        /// <summary>
        /// Get a Collection of Not Deleted TEntity.
        /// </summary>
        /// <typeparam name="TEntity">System SoftDeletableEntity</typeparam>
        /// <param name="query">filters</param>
        /// <param name="include">Array of properties to include.</param>
        /// <returns>A materialized collection of TEntity.</returns>
        Task<List<TEntity>> GetNotDeletedCollectionAsync<TEntity>(Expression<Func<TEntity, bool>> query, params Expression<Func<TEntity, object>>[] include)
            where TEntity : Entity, ISoftDeletableEntity;

        /// <summary>
        /// Get all active entities of type TEntity.
        /// </summary>
        /// <typeparam name="TEntity">System Entity</typeparam>
        /// <returns>A materialized collection of TEntity.</returns>
        Task<List<TEntity>> GetActiveCollectionAsync<TEntity>() where TEntity : Entity;

        /// <summary>
        /// Get if exist rows of type TEntity.
        /// </summary>
        /// <typeparam name="TEntity">SoftDeletable Entity</typeparam>
        /// <returns>boolean</returns>
        Task<bool> AnyNotDeletedAsync<TEntity>(Expression<Func<TEntity, bool>> query)
            where TEntity : Entity, ISoftDeletableEntity;

        /// <summary>
        /// AddSoftDeletableEntity to dbcontext and set softdeleted properties
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entity"></param>
        void AddSoftDeletableEntity<TEntity>(TEntity entity) where TEntity : Entity,
        ISoftDeletableEntity;

        /// <summary>
        /// AddSoftDeletableEntityIgnoringIsActive dbcontext and set softdeleted properties without changing IsActive
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entity"></param>
        void AddSoftDeletableEntityIgnoringIsActive<TEntity>(TEntity entity) where TEntity : Entity,
        ISoftDeletableEntity;

        Task<long> GetNextEntitySequence<TEntity>() where TEntity : Entity;
        Task<string> GetNextEntityCode<TEntity>() where TEntity : Entity, IHaveCode;

        /// <summary>
        /// Return the CrpId of an entity by its id.
        /// </summary>
        /// <typeparam name="TEntity">Crp Entity</typeparam>
        /// <param name="id">Id of the entity</param>
        /// <returns>CrpId</returns>

        /// <summary>
        /// Save changes to Database.
        /// </summary>
        /// <returns>Number of changes executed against Database.</returns>
        Task<int> SaveChangesAsync();

        /// <summary>
        /// Save changes and set the Entity.CreatedById with the supplied param
        /// </summary>
        /// <param name="createdById"></param>
        /// <returns></returns>
        Task<int> SaveChangesAsync(int createdById);

        void InsertCollection<TEntity>(IEnumerable<TEntity> entityList) where TEntity : Entity;

        void UpdateCollection<TEntity>(IEnumerable<TEntity> entityList) where TEntity : Entity;

        Task<int> ExecuteSqlCommandAsync(string sql, params object[] parameters);

        Task<List<T>> SqlQuery<T>(string sql, params object[] parameters);

        Task<int> ExecuteSqlCommandAsync(ExecuteSqlCommandParameter executeParameter);

        DateTime GetCurrentUserDate();
    }

    public class ExecuteSqlCommandParameter
    {
        public string Sql { get; set; }
        public int CommandTimeOut { get; set; } = 30;
        public object[] Parameters { get; set; } = new List<string>().ToArray();
    }
}
