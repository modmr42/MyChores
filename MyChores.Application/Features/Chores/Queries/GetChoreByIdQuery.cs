using MediatR;
using Microsoft.EntityFrameworkCore;
using MyChores.Application.Features.Chores.Dtos;
using MyChores.Application.Interfaces;
using MyChores.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyChores.Application.Features.Chores.Queries
{

    public class GetChoreByIdForUserQuery :IRequest<ChoreDto>
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
    }


    public class GetChoreByIdQueryHandler : IRequestHandler<GetChoreByIdForUserQuery, ChoreDto?>
    {
        private readonly IMyChoresDbContext _context;
        public GetChoreByIdQueryHandler(IMyChoresDbContext context)
        {
            _context = context;
        }
        public async Task<ChoreDto?> Handle(GetChoreByIdForUserQuery request, CancellationToken cancellationToken)
        {
            var culture = CultureInfo.CreateSpecificCulture("nl-NL");

            var result = await _context.Chores.Where(x => x.UserId.Equals(request.UserId))
                .Select(chore => new ChoreDto
            {
                Id = chore.Id,
                Name = chore.Name,
                Description = chore.Description,
                ChoreOwner = chore.ChoreOwner,
                ChoreTaker = chore.ChoreTaker,
                Completed = chore.Completed,
                DayOfWeek = chore.DayOfWeek.ToString(),
                Recourse = chore.Recourse.ToString(),
                CreatedDate = chore.CreatedDate.ToString(culture), // move the format to constants
                LastModifiedDate = chore.LastModifiedDate.ToString(culture)

            }).FirstOrDefaultAsync(x => x.Id.Equals(request.Id), cancellationToken);

            return result;
        }
    }
}
