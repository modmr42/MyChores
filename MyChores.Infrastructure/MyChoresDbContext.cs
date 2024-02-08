using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MyChores.Application.Interfaces;
using MyChores.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyChores.Infrastructure
{
    public class MyChoresDbContext : IdentityDbContext<MyChoresUserEntity>, IMyChoresDbContext
    {
        private IConfiguration Configuration { get; }
        public DbSet<ChoreEntity> Chores { get; set; }

        public MyChoresDbContext(DbContextOptions<MyChoresDbContext> options, IConfiguration configuration)
            : base(options)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            ModelCreatingExtension.ConfigureModels(modelBuilder);
        }

    }
}
