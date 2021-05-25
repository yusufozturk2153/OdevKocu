using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServerOdevKocu.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerOdevKocu.Data.FluentApiConfiguration
{
    public class StudentBookConfiguration : IEntityTypeConfiguration<StudentBook>
    {
        public void Configure(EntityTypeBuilder<StudentBook> builder)
        {
            builder.HasOne(sb => sb.Book).WithMany(b => b.StudentBooks).HasForeignKey(sb => sb.BookId);
            builder.HasOne(sb => sb.Student).WithMany(s => s.StudentBooks).HasForeignKey(sb => sb.StudentId);
        }
    }
}
