using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServerOdevKocu.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerOdevKocu.Data.FluentApiConfiguration
{
    public class HomeworkTaskConfiguration : IEntityTypeConfiguration<HomeworkTask>
    {
        public void Configure(EntityTypeBuilder<HomeworkTask> builder)
        {
            builder.HasOne(ht => ht.Homework).WithMany(h => h.HomeworkTasks)
                .HasForeignKey(ht => ht.HomeworkId);
        }
    }
}
