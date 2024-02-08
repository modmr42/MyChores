using Microsoft.EntityFrameworkCore;
using MyChores.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyChores.Application.Interfaces
{
    public interface IMyChoresDbContext
    {
        public DbSet<ChoreEntity> Chores { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
