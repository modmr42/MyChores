using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyChores.Infrastructure
{
    public class ModelCreatingExtension
    {
        public static void ConfigureModels(ModelBuilder modelBuilder)
        {
            //QuestionEntity.OnModelCreating(modelBuilder.Entity<QuestionEntity>());
        }
    }
}
