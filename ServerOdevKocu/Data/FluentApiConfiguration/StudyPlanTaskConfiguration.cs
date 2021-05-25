using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServerOdevKocu.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerOdevKocu.Data.FluentApiConfiguration
{
    public class StudyPlanTaskConfiguration : IEntityTypeConfiguration<StudyPlanTask>
    {
        public void Configure(EntityTypeBuilder<StudyPlanTask> builder)
        {
            builder.HasOne(spt => spt.HomeworkTask).WithMany(ht => ht.StudyPlanTasks).HasForeignKey(spt => spt.HomeworkTaskId);
            builder.HasOne(spt => spt.StudyPlan).WithMany(ht => ht.StudyPlanTasks).HasForeignKey(spt => spt.StudyPlanId);
        }
    }
}
