using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyChores.Domain.Entities
{
    public class AppUserEntity : IdentityUser
    {
        //todo apikey
        //guest users

        public ICollection<ChoreEntity> Chores { get; set; }
    }
}
