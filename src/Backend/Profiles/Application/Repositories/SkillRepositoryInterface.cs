// Licensed to the .NET Foundation under one or more agreements.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Profiles.Application.Responses;
using Shared.Application.Interfaces;

namespace Profiles.Application.Repositories
{
    public interface ISkillRepository<TEntity>: IRepository<TEntity> where TEntity : class
    {

        public Task<TEntity> AddAsync(RegisterSkillApplicationResponse entity);
        //public Task<TEntity> UpdateAsync(Guid id, UpdateCountryApplicationResponse entity);

    }
}
