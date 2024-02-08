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
    public class DeleteChoreCommand : IRequest
    {
        public Guid Id { get; set; }
    }

    public class DeleteChoreCommandHandler : IRequestHandler<DeleteChoreCommand>
    {
        private readonly IMyChoresDbContext _context;
        public DeleteChoreCommandHandler(IMyChoresDbContext context) 
        {
            _context = context;
        }
        public async Task Handle(DeleteChoreCommand command, CancellationToken cancellationToken)
        {

            var entity = await _context.Chores.FindAsync(command.Id, cancellationToken);

            if (entity == null)
                throw new Exception($"Can't find entity with id:{command.Id} to delete");

            _context.Chores.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);


        }
    }
}
