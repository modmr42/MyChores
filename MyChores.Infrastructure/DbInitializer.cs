using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MyChores.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyChores.Infrastructure
{
    public static class DbInitializer
    {
        public static void WaitOnDbCreated(ILogger logger)
        {
            logger.LogDebug("Waiting on database...");
            Task.Delay(5000).Wait();
            logger.LogDebug("Done waiting on database...");
        }

        public static void Initialize(MyChoresDbContext context)
        {
            //Apply migrations to the database
            context.Database.Migrate();

            context.SaveChanges();
            return;
        }

        public static async Task AddTestUser(UserManager<AppUserEntity> userManager)
        {
            var user = new AppUserEntity
            {
                Email = "tester@tester.nl",
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = "tester"
            };

            try
            {
                await userManager.CreateAsync(user, "tester");
            }
            catch (Exception ex) { }
        }
    }
}
