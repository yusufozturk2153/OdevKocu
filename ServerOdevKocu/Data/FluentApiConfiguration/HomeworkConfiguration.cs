using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServerOdevKocu.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerOdevKocu.Data.FluentApiConfiguration
{
    public class HomeworkConfiguration : IEntityTypeConfiguration<Homework>
    {
        public void Configure(EntityTypeBuilder<Homework> builder)
        {
            builder.HasOne(h => h.Student).WithMany(s => s.Homeworks).HasForeignKey(h => h.StudentId);
            builder.HasOne(h => h.Teacher).WithMany(t => t.Homeworks).HasForeignKey(h => h.TeacherId);
        }
    }
}
