using MyChores.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyChores.Application.Interfaces
{
    public interface IChoreCommandRepository
    {
        Task<Guid> CreateAsync(ChoreEntity entity);
        Task DeleteAsync(Guid id);
    }

    public interface IChoreQueryRepository
    {
        Task<ChoreEntity> GetAsync(Guid id);
        Task<ICollection<ChoreEntity>> GetAllAsync();
    }
}
