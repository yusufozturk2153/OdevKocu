using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServerOdevKocu.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerOdevKocu.Data.FluentApiConfiguration
{
    public class BookSubjectConfiguration : IEntityTypeConfiguration<BookSubject>
    {
        public void Configure(EntityTypeBuilder<BookSubject> builder)
        {
            builder.HasKey(bs => new { bs.BookId, bs.SubjectId });
            builder.HasOne(bs => bs.Book).WithMany(b => b.BookSubjects).HasForeignKey(bs => bs.BookId);
            builder.HasOne(bs => bs.Subject).WithMany(s => s.BookSubjects).HasForeignKey(bs => bs.SubjectId);
        }
    }
}
