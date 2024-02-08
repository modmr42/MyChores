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
    public class UpdateChoreCommand : IRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        //public bool Completed { get; set; }
        public string ChoreOwner { get; set; }
        public string ChoreTaker { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public Recourse Recourse { get; set; }
    }

    public class UpdateChoreCommandHandler : IRequestHandler<UpdateChoreCommand>
    {
        private readonly IMyChoresDbContext _context;
        public UpdateChoreCommandHandler(IMyChoresDbContext context) 
        {
            _context = context;
        }
        public async Task Handle(UpdateChoreCommand command, CancellationToken cancellationToken)
        {
            var entity = await _context.Chores.FindAsync(command.Id); //todo maybe first or default better

            if (entity == null)
                throw new Exception($"The entity with id: {command.Id} was not found");

            entity.Name = command.Name;
            entity.Description = command.Description;
            entity.ChoreOwner = command.ChoreOwner;
            entity.LastModifiedDate = DateTime.Now;
            entity.DayOfWeek = command.DayOfWeek;
            entity.Recourse = command.Recourse;

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
