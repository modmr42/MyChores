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

    public class DeleteChoreForUserCommand : IRequest
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
    }


    public class DeleteChoreCommandHandler : IRequestHandler<DeleteChoreForUserCommand>
    {
        private readonly IMyChoresDbContext _context;
        public DeleteChoreCommandHandler(IMyChoresDbContext context) 
        {
            _context = context;
        }
        public async Task Handle(DeleteChoreForUserCommand command, CancellationToken cancellationToken)
        {

            var entity = await _context.Chores.FindAsync(command.Id, cancellationToken);

            if (entity == null)
                throw new Exception($"Can't find entity with id:{command.Id} to delete");

            if(!entity.UserId.Equals(command.UserId))
                throw new Exception($"Can't find entity with id:{command.Id} of user with id:{command.UserId} to delete");

            _context.Chores.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);


        }
    }
}
