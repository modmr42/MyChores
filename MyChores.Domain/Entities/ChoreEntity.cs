using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyChores.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyChores.Domain.Entities
{
    public class ChoreEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Description { get; set; }

        public bool Completed { get; set; }
        public string ChoreOwner { get; set; }
        public string ChoreTaker { get; set; }
        public DateTime DateTime { get; set; }
        public Recourse Recourse { get; set; }
        public DateTime CreatedDate { get; set;}
        public DateTime LastModifiedDate { get; set;}

        public string UserId { get; set; }
        public AppUserEntity User { get; set; }


        public static void OnModelCreating(EntityTypeBuilder<ChoreEntity> entity)
        {
            entity.HasKey(e => e.Id);

            entity.HasOne(x => x.User)
                .WithMany(x => x.Chores)
                .HasForeignKey(x => x.UserId);
        }

    }
}
