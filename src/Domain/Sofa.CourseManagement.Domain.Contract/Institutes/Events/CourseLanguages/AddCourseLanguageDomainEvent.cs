using Sofa.CourseManagement.Domain.Contract.Institutes.Enums;
using Sofa.SharedKernel.EventProcessing.DomainEvent;

namespace Sofa.CourseManagement.Domain.Contract.Institutes.Events.CourseLanguages
{
	public class AddCourseLanguageDomainEvent : DomainEventBase
	{
		public AddCourseLanguageDomainEvent()
		{
			
		}
		public AddCourseLanguageDomainEvent(Guid id, LanguageEnum language, Guid courseId, Guid fieldId, Guid instituteId)
		{
			Id = id;
			Language = language;
			CourseId = courseId;
			FieldId = fieldId;
			InstituteId = instituteId;
		}

		public Guid Id { get; set; }
		public LanguageEnum Language { get; set; }
		public Guid CourseId { get; set; }
		public Guid FieldId { get; set; }
		public Guid InstituteId { get; set; }
	}
}
