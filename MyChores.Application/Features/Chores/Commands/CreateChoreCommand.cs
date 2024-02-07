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
    public class CreateChoreCommand
    {
        public string Name { get; set; }
        public string Description { get; set; }

        //public bool Completed { get; set; }
        public string ChoreOwner { get; set; }
        public string ChoreTaker { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public Recourse Recourse { get; set; }
    }

    public class CreateChoreCommandHandler //todo mediatr
    {
        private readonly IChoreCommandRepository _repository;
        public CreateChoreCommandHandler(IChoreCommandRepository repository) 
        {
            _repository = repository;
        }

        public async Task<Guid> Handle(CreateChoreCommand command)
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

            return await _repository.CreateAsync(entity);

        }
    }
}
