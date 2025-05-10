using Microsoft.EntityFrameworkCore;
using Sofa.CourseManagement.Domain.Institutes;
using Sofa.CourseManagement.Domain.Institutes.Entities;
using Sofa.CourseManagement.Domain.Institutes.Entities.Courses;
using Sofa.CourseManagement.Domain.Institutes.Entities.LessonPlans;
using Sofa.CourseManagement.Domain.Institutes.Entities.Posts;
using Sofa.CourseManagement.Domain.Institutes.Entities.Sessions;
using Sofa.CourseManagement.Domain.Institutes.Entities.Users;
using Sofa.CourseManagement.Domain.Users;
using Sofa.CourseManagement.Infrastructure.Domains.Institutes;
using Sofa.CourseManagement.Infrastructure.Domains.Institutes.Entieis;
using Sofa.CourseManagement.Infrastructure.Domains.Users;

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
			builder.ApplyConfiguration(new InstituteEntityConfiguration());
			builder.ApplyConfiguration(new InstituteUserEntiityConfiguration());
            builder.ApplyConfiguration(new FieldEntityConfiguration());
            builder.ApplyConfiguration(new FieldQuestionEntityConfiguration());
			builder.ApplyConfiguration(new FieldQuestionChoiceEntityConfiguration());
			builder.ApplyConfiguration(new CourseEntityConfiguration());
			builder.ApplyConfiguration(new CourseUserEntityConfiguration());
			builder.ApplyConfiguration(new CoursePlacementEntityConfiguration());
            builder.ApplyConfiguration(new CoursePlacementQuestionEntityConfiguration());
			builder.ApplyConfiguration(new CourseLanguageEntityConfiguration());
			builder.ApplyConfiguration(new SessionEntityConfiguration());
            builder.ApplyConfiguration(new LessonPlanEntityConfigration());
            builder.ApplyConfiguration(new PostBaseEntityConfiguration());
            builder.ApplyConfiguration(new ImagePostEntityConfiguration());
            builder.ApplyConfiguration(new SoundPostEntityConfiguration());
            builder.ApplyConfiguration(new TextPostEntityConfiguration());
            builder.ApplyConfiguration(new VideoPostEntityConfiguration());
			builder.ApplyConfiguration(new PostQuestionEntityConfiguration());

			base.OnModelCreating(builder);
            //builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        }

        public DbSet<User> Users { get; set; }
		public DbSet<Institute> Institutes { get; set; }
		public DbSet<InstituteUser> InstituteUsers { get; set; }
		public DbSet<Field> Fields { get; set; }
		public DbSet<FieldQuestion> FieldQuestions { get; set; }
		public DbSet<FieldQuestionChoice> FieldQuestionChoices { get; set; }
		public DbSet<Course> Courses { get; set; }
		public DbSet<CourseUser> CourseUsers { get; set; }
		public DbSet<CoursePlacement> CoursePlacements { get; set; }
		public DbSet<CourseLanguage> CourseLanguages { get; set; }
		public DbSet<CoursePlacementQuestion> CoursePlacementQuestions { get; set; }
		public DbSet<Session> Sessions { get; set; }
        public DbSet<LessonPlan> LessonPlans { get; set; }
        public DbSet<PostBase> Posts { get; set; }
        public DbSet<ImagePost> ImagePosts { get; set; }
        public DbSet<SoundPost> SoundPosts { get; set; }
        public DbSet<TextPost> TextPosts { get; set; }
        public DbSet<VideoPost> VideoPosts { get; set; }
		public DbSet<PostQuestion> PostQuestions { get; set; }

	}
}
