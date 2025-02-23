using Sofa.CourseManagement.Domain.Contract.Institutes.Enums;
using Sofa.CourseManagement.SharedKernel.EventProcessing.DomainEvent;

namespace Sofa.CourseManagement.Domain.Contract.Institutes.Events.CourseLanguages
{
	public class UpdateCourseLanguageDomainEvent : DomainEventBase
	{
		public UpdateCourseLanguageDomainEvent()
		{
			
		}
		public UpdateCourseLanguageDomainEvent(Guid id, LanguageEnum language, Guid courseId)
		{
			Id = id;
			Language = language;
			CourseId = courseId;
		}

		public Guid Id { get; }
		public LanguageEnum Language { get; }
		public Guid CourseId { get; }
	}
}
