using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ScheduleProg.Models;

namespace ScheduleProg.Data
{

    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public DbSet<Group> Groups { get; set; }
        public DbSet<PairTime> PairTimes { get; set; }
        public DbSet<Pare> Schedules { get; set; }
        public DbSet<Semester> Semesters { get; set; }

        public DbSet<Student> Students { get; set; }

        public DbSet<Teacher> Teachers { get; set; }

        public DbSet<Subgroup> Subgroups { get; set; }

        public DbSet<PareSubgroup> PareSubgroups { get; set; }

        public DbSet<Potok> Potoks { get; set; }

        public DbSet<Pare> Pares { get; set; }
        public DbSet<ScheduleProg.Models.Subject> Subject { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }




       


        protected override void OnModelCreating(ModelBuilder builder)
        {
            /*b*/
            base.OnModelCreating(builder);
            builder.Entity<Semester>()
            .HasMany<Pare>(semester => semester.Pares)
            .WithOne(pare => pare.Semester)
            .HasForeignKey(pare => pare.Semester_Id);
            /*e*/
            /*  builder.Entity<Group>()
             .HasMany<Pare>(group => group.Pares)
             .WithOne(pare => pare.Group)
             .HasForeignKey(pare => pare.Group_Id);*/

            /*b*/
            builder.Entity<Subject>()
          .HasMany<Pare>(s => s.Pares)
          .WithOne(p => p.Subject)
          .HasForeignKey(p => p.Subject_Id);
            /*e*/

            /*b*/
            builder.Entity<Teacher>()
          .HasMany<Pare>(teacher => teacher.Pares)
          .WithOne(pare => pare.Teacher)
          .HasForeignKey(pare => pare.Teacher_Id);
            /*e*/

            /*b*/
            builder.Entity<PairTime>()
          .HasMany<Pare>(pairtime => pairtime.Pares)
          .WithOne(pare => pare.PairTime)
          .HasForeignKey(pare => pare.Pair_Time_Id);
            /*e*/

            /*b*/
            builder.Entity<PareSubgroup>()
          .HasOne<Pare>(ps => ps.Pare)
          .WithMany(p=> p.PareSubgroups)
          .HasForeignKey(ps => ps.Pare_Id);
            /*e*/

            /*Many-to-Many */
            builder.Entity<PareSubgroup>().HasKey(ps => new { ps.Pare_Id, ps.Subgroup_Id });
           builder.Entity<PareSubgroup>()
          .HasOne<Subgroup>(ps => ps.Subgroup)
          .WithMany(s => s.PareSubgroups)
          .HasForeignKey(ps => ps.Subgroup_Id);
           builder.Entity<Potok>()
          .HasMany<Group>(g=>g.Groups)
          .WithOne(p=>p.Potok)
          .HasForeignKey(g=>g.Potok_Id);
            /*e*/

            /*b*/
            builder.Entity<Group>()
            .HasMany<Subgroup>(s=>s.Subgroups)
            .WithOne(g=>g.Group)
            .HasForeignKey(g=>g.Group_Id);
            /*e*/

            /*b*/
            builder.Entity<Subgroup>()
            .HasMany<Student>(s => s.Students)
            .WithOne(g => g.Subgroup)
            .HasForeignKey(g => g.Subgroup_Id);

            builder.Entity<Student>()
            .HasOne(a => a.User)
            .WithOne(b => b.Student)
            .HasForeignKey<Student>(b => b.User_Id);

            builder.Entity<Teacher>()
            .HasOne(a => a.User)
            .WithOne(b => b.Teacher)
            .HasForeignKey<Teacher>(b => b.User_Id);









        }

        
    }
}