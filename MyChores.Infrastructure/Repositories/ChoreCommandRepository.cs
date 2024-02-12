using Microsoft.EntityFrameworkCore;
using MyChores.Application.Interfaces;
using MyChores.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyChores.Infrastructure.Repositories
{
    public class ChoreCommandRepository : IChoreCommandRepository
    {
        private readonly MyChoresDbContext _context;
        public ChoreCommandRepository(MyChoresDbContext context)
        {
            _context = context;
        }
        public async Task<Guid> CreateAsync(ChoreEntity entity)
        {
            await _context.Chores.AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity.Id;
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await _context.Chores.FirstOrDefaultAsync(x => x.Id.Equals(id));

            if(entity != null)
            {
                _context.Chores.Remove(entity);
                await _context.SaveChangesAsync();
            }
            else throw new Exception($"Chore with id {id} not found.");
        }

        public Task UpdateAsync(ChoreEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
