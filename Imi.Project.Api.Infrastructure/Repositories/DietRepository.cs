using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Interfaces;
using Imi.Project.Api.Core.Interfaces.Repositories;
using Imi.Project.Api.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Infrastructure.Repositories
{
    public class DietRepository : BaseRepository<Diet>, IDietRepository
    {
        public DietRepository(AnimalDbContext dbContext) : base(dbContext)
        {

        }

    }
}
