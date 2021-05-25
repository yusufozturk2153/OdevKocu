using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServerOdevKocu.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerOdevKocu.Data.FluentApiConfiguration
{
    public class StudyPlanConfiguration : IEntityTypeConfiguration<StudyPlan>
    {
        public void Configure(EntityTypeBuilder<StudyPlan> builder)
        {
            builder.HasOne(sp => sp.Student).WithMany(s => s.StudyPlans).HasForeignKey(sp => sp.StudentId);
            builder.HasOne(sp => sp.Teacher).WithMany(s => s.StudyPlans).HasForeignKey(sp => sp.TeacherId);
        }
    }
}
