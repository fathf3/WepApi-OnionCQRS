using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Application.Interfaces.Repositories;
using WebApi.Application.Interfaces.UnitOfWorks;
using WebApi.Persistence.Context;
using WebApi.Persistence.Repositories;

namespace WebApi.Persistence.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext appDbContext;

        public UnitOfWork(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public async ValueTask DisposeAsync() => await appDbContext.DisposeAsync();

        public int Save() => appDbContext.SaveChanges();

        public async Task<int> SaveAsync() => await appDbContext.SaveChangesAsync();

        IReadRepository<T> IUnitOfWork.GetReadRepository<T>() => new ReadRepository<T>(appDbContext);

        IWriteRepository<T> IUnitOfWork.IWriteRepository<T>() => new WriteRepository<T>(appDbContext);
    }
}
