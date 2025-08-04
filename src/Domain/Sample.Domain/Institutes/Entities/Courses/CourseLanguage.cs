using Sofa.CourseManagement.Domain.Contract.Institutes.Enums;
using Sofa.CourseManagement.Domain.Contract.Institutes.Events.CourseLanguages;
using Sofa.CourseManagement.Domain.Institutes.ValueObjects;
using Sofa.SharedKernel.SeedWork;
using System;

namespace Sofa.CourseManagement.Domain.Institutes.Entities.Courses
{
	public class CourseLanguage : Entity<Guid>
	{
		private CourseLanguage() : base()
		{
			
		}
		private CourseLanguage(Guid id, LanguageEnum language, Guid courseId) : this()
		{
			AssignId(id);
			AssignLanguage(language);
			AssignCourse(courseId);
		}

		public Language Language { get; private set; }
		public Guid CourseId { get; private set; }
		public Course Course { get; private set; }

		public void AssignLanguage(LanguageEnum language) { Language = language; }
		public void AssignCourse(Guid courseId) {  CourseId = courseId; }

		public static CourseLanguage CreateInstance(Guid id, LanguageEnum language, Guid courseId) 
		{
			var instance = new CourseLanguage(id, language, courseId);

			instance.AddDomainEvent(new AddCourseLanguageDomainEvent(id, language, courseId));

			return instance;
		}
		public void Delete()
		{
			MarkAsDeleted();
			AddDomainEvent(new DeleteCourseLanguageDomainEvent(Id));
		}
		public void Update(LanguageEnum language, Guid courseId)
		{
			AssignLanguage(language);
			AssignCourse(courseId);
			base.MarkAsUpdated();

			AddDomainEvent(new UpdateCourseLanguageDomainEvent(Id, language, courseId));
		}
	}
}
