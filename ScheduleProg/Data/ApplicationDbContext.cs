using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ScheduleProg.Models;

namespace ScheduleProg.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Group> Groups { get; set; }
        public DbSet<PairTime> PairTimes { get; set; }
        public DbSet<Pare> Schedules { get; set; }
        public DbSet<Semester> Semesters { get; set; }

        public DbSet<Student> Students { get; set; }

        public DbSet<Teacher> Teachers { get; set; }



        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Semester>()
            .HasMany<Pare>(semester => semester.Pares)
            .WithOne(pare => pare.Semester)
            .HasForeignKey(pare => pare.Semester_Id);
            builder.Entity<Group>()
           .HasMany<Pare>(group => group.Pares)
           .WithOne(pare => pare.Group)
           .HasForeignKey(pare => pare.Group_Id);
            builder.Entity<Subject>()
          .HasMany<Pare>(group => group.Pares)
          .WithOne(pare => pare.Subject)
          .HasForeignKey(pare => pare.Subject_Id);
            builder.Entity<Teacher>()
          .HasMany<Pare>(group => group.Pares)
          .WithOne(pare => pare.Teacher)
          .HasForeignKey(pare => pare.Teacher_Id);
            builder.Entity<PairTime>()
          .HasMany<Pare>(group => group.Pares)
          .WithOne(pare => pare.PairTime)
          .HasForeignKey(pare => pare.Pair_Time_Id);






        }
    }
}