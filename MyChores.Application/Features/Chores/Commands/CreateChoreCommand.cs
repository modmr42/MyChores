using MediatR;
using MyChores.Application.Interfaces;
using MyChores.Domain.Entities;
using MyChores.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyChores.Application.Features.Chores.Commands
{
    public class CreateChoreCommand : IRequest<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }

        //public bool Completed { get; set; }
        public string ChoreOwner { get; set; }
        public string ChoreTaker { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public Recourse Recourse { get; set; }
    }

    public class CreateChoreCommandHandler : IRequestHandler<CreateChoreCommand, Guid>
    {
        private readonly IMyChoresDbContext _context;
        public CreateChoreCommandHandler(IMyChoresDbContext context) 
        {
            _context = context;
        }
        public async Task<Guid> Handle(CreateChoreCommand command, CancellationToken cancellationToken)
        {
            var entity = new ChoreEntity
            {
                Name = command.Name,
                Description = command.Description,
                ChoreOwner = command.ChoreOwner,
                ChoreTaker = command.ChoreTaker,
                CreatedDate = DateTime.Now,
                LastModifiedDate = DateTime.Now,
                DayOfWeek = command.DayOfWeek,
                Recourse = command.Recourse,
            };

            await _context.Chores.AddAsync(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;

        }
    }
}
