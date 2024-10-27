using Microsoft.EntityFrameworkCore;
using Sofa.CourseManagement.Domain.Institutes;
using Sofa.CourseManagement.Domain.Institutes.Entities;
using Sofa.CourseManagement.Domain.LessonPlans;
using Sofa.CourseManagement.Domain.LessonPlans.Entities;
using Sofa.CourseManagement.Infrastructure.Domains.Institutes;
using Sofa.CourseManagement.Infrastructure.Domains.Institutes.Entieis;
using Sofa.CourseManagement.Infrastructure.Domains.LessonPlans;
using Sofa.CourseManagement.Infrastructure.Domains.LessonPlans.Entities;
using System.Reflection;

namespace Sofa.CourseManagement.Infrastructure.Persistence
{
    public class CourseManagementDbContext : DbContext
    {
        public CourseManagementDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserEntiityConfiguration());
            builder.ApplyConfiguration(new UserCourseEntiityConfiguration());
            builder.ApplyConfiguration(new InstituteEntityConfiguration());
            builder.ApplyConfiguration(new FieldEntityConfiguration());
            builder.ApplyConfiguration(new TermEntityConfiguration());
            builder.ApplyConfiguration(new SessionEntityConfiguration());
            builder.ApplyConfiguration(new CourseEntityConfiguration());
            builder.ApplyConfiguration(new LessonPlanEntityConfigration());
            builder.ApplyConfiguration(new PostBaseEntityConfiguration());
            builder.ApplyConfiguration(new ImagePostEntityConfiguration());
            builder.ApplyConfiguration(new SoundPostEntityConfiguration());
            builder.ApplyConfiguration(new TextPostEntityConfiguration());
            builder.ApplyConfiguration(new VideoPostEntityConfiguration());

            base.OnModelCreating(builder);
            //builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserCourse> UserCourses { get; set; }
        public DbSet<Institute> Institutes { get; set; }
        public DbSet<Field> Fields { get; set; }
        public DbSet<Term> Terms { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<LessonPlan> LessonPlans { get; set; }
        public DbSet<PostBase> Posts { get; set; }
        public DbSet<ImagePost> ImagePosts { get; set; }
        public DbSet<SoundPost> SoundPosts { get; set; }
        public DbSet<TextPost> TextPosts { get; set; }
        public DbSet<VideoPost> VideoPosts { get; set; }

    }
}
