using Hastane.Core.DataAccess.Abstract;
using Hastane.Core.Entities.Abstract;
using Hastane.DataAccess.EntityFramework.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Hastane.DataAccess.EntityFramework.Concrete
{
    public class BaseRepo<T> : IBaseRepo<T> where T : class, IBaseEntity
    {
        private readonly HastaneDbContext _hastaneDbContext;
        protected DbSet<T> _table;
        public BaseRepo(HastaneDbContext hastaneDbContext)
        {
            _hastaneDbContext = hastaneDbContext;
            _table =_hastaneDbContext.Set<T>();
        }

        public async Task<bool> Add(T entity)
        {
            await _table.AddAsync(entity);
            return await Save() > 0;
        }

        public async Task<bool> AddRange(List<T> entities)
        {
            await _table.AddRangeAsync(entities);
            return await Save() > 0;
        }

        public async Task<bool> Delete(T entity)
        {
            entity.Status = Core.Enums.Status.Passive;
            return await Save() > 0; 
        }

        public async Task<List<T>> GetAll()=>await _table.Where(i => i.Status==Core.Enums.Status.Active).ToListAsync();

        public async Task<T> GetById(Guid id) => await _table.FindAsync(id);

        public async Task<int> Save()
        {
            return await _hastaneDbContext.SaveChangesAsync();
        }

        public async Task<bool> Update(T entity)
        {
            _hastaneDbContext.Entry<T>(entity).State= EntityState.Modified;
            return await Save() > 0;
        }
    }
    
}
