using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DevCA.Business.Interfaces.Repository;
using DevCA.Business.Model;
using DevCa.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace DevCa.Data.Repository
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity, new()
    {
        protected readonly BruceComicsContext Db;
        protected readonly DbSet<TEntity> DbSet;

        protected Repository(BruceComicsContext db)
        {
            Db = db;
            DbSet = db.Set<TEntity>();
        }
        
        public void Dispose()
        {
            Db?.Dispose();
        }

        public async Task Add(TEntity entity)
        {
            DbSet.Add(entity);
            await SaveChanges();
        }

        public async Task<TEntity> GetById(long id)
        {
            return await DbSet.FindAsync(id);
        }

        public async Task<List<TEntity>> GetAll()
        {
            return await DbSet.ToListAsync();
        }

        public async Task Update(TEntity entity)
        {
            DbSet.Update(entity);
            await SaveChanges();
        }

        public async Task Remove(long id)
        {
            DbSet.Remove(new TEntity { Id = id });
            await SaveChanges();
        }

        public async Task<IEnumerable<TEntity>> Search(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbSet.AsNoTracking().Where(predicate).ToListAsync();
        }

        public async Task<int> SaveChanges()
        {
            return await Db.SaveChangesAsync();
        }
    }
}