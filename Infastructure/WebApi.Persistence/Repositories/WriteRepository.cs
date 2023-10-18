using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Application.Interfaces.Repositories;
using WebApi.Domain.Common;
using WebApi.Persistence.Context;

namespace WebApi.Persistence.Repositories
{
    public class WriteRepository<T> : IWriteRepository<T> where T : class, IEntityBase, new()
    {
        private readonly AppDbContext appDbContext;

        public WriteRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        private DbSet<T> Table { get => appDbContext.Set<T>(); }

        public async Task AddAsync(T entity)
        {
            await Table.AddAsync(entity);
        }

        public async Task AddRangeAsync(IList<T> entites)
        {
            await Table.AddRangeAsync(entites);
        }

        public async Task<T> HardDeleteAsync(T entity)
        {
            await Task.Run(() => Table.Remove(entity));
        }

        

        public async Task<T> UpdateAsync(T entity)
        {
            await Task.Run(() => Table.Update(entity));
            return entity;
        }
    }

}
