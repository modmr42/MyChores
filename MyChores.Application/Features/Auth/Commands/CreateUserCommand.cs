using MediatR;
using Microsoft.AspNetCore.Identity;
using MyChores.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyChores.Application.Features.Auth.Commands
{
    public class CreateUserCommand : IRequest<string>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }

    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, string>
    {
        private readonly UserManager<AppUserEntity> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public CreateUserCommandHandler(UserManager<AppUserEntity> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<string> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var entity = new AppUserEntity
            {
                UserName = request.UserName,
                Email = request.Email,
            };

            var result = await _userManager.CreateAsync(entity, request.Password);

            if (!result.Succeeded)
                throw new Exception($"Can't make new user with name: {request.UserName}");

            if (!await _roleManager.RoleExistsAsync(AppUserRoles.User))
                await _roleManager.CreateAsync(new IdentityRole(AppUserRoles.User));

            if (await _roleManager.RoleExistsAsync(AppUserRoles.User))
                await _userManager.AddToRoleAsync(entity, AppUserRoles.User);

            return entity.Id;


        }
    }

}
