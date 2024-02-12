using MyChores.Application.Features.Chores.Commands;

namespace MyChores.API.Mappers
{
    public static class ChoreMapper
    {
        public static CreateChoreForUserCommand Map(CreateChoreCommand command, string userId)
        {
            return new CreateChoreForUserCommand
            {
                Name = command.Name,
                Description = command.Description,
                Completed = command.Completed,
                ChoreOwner = command.ChoreOwner,
                ChoreTaker = command.ChoreTaker,
                DayOfWeek = command.DayOfWeek,
                Recourse = command.Recourse,
                UserId = userId,
            };
        }
        public static UpdateChoreForUserCommand Map(UpdateChoreCommand command, string userId)
        {
            return new UpdateChoreForUserCommand
            {
                Id = command.Id,
                Name = command.Name,
                Description = command.Description,
                Completed = command.Completed,
                ChoreOwner = command.ChoreOwner,
                ChoreTaker = command.ChoreTaker,
                DayOfWeek = command.DayOfWeek,
                Recourse = command.Recourse,
                UserId = userId,
            };
        }

    }
}
