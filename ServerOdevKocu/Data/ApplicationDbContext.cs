using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ServerOdevKocu.Data.Entities;
using ServerOdevKocu.Data.FluentApiConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerOdevKocu.Data
{
    public class ApplicationDbContext:IdentityDbContext<AppUser,AppRole,int> 
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Homework> Homeworks { get; set; }
        public DbSet<HomeworkTask> HomeworkTasks { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<StudyPlan> StudyPlans { get; set; }
        public DbSet<StudyPlanTask> StudyPlanTasks { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<BookSubject> BookSubjects { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new StudentConfiguration());
            builder.ApplyConfiguration(new BookConfiguration());
            builder.ApplyConfiguration(new HomeworkTaskConfiguration());
            builder.ApplyConfiguration(new BookSubjectConfiguration());
            builder.ApplyConfiguration(new HomeworkConfiguration());
            builder.ApplyConfiguration(new StudyPlanConfiguration());
            builder.ApplyConfiguration(new StudyPlanTaskConfiguration()); 



        }

    }
}
