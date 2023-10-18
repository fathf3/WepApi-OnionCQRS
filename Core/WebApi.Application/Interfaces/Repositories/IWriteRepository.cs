﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Domain.Common;

namespace WebApi.Application.Interfaces.Repositories
{
    public interface IWriteRepository<T> where T : class, IEntityBase , new()
    {
        Task AddAsync(T entity);
        Task AddRangeAsync(IList<T> entites);
        Task<T> UpdateAsync(T entity);
        Task<T> HardDeleteAsync(T entity);
        


    }
}