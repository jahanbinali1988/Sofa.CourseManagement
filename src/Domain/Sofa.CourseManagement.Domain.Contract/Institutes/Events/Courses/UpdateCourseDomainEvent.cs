using Sofa.CourseManagement.Domain.Contract.Institutes.Enums;
using Sofa.SharedKernel.EventProcessing.DomainEvent;

namespace Sofa.CourseManagement.Domain.Contract.Institutes.Events.Courses
{
	public class UpdateCourseDomainEvent : DomainEventBase
	{

		public UpdateCourseDomainEvent() : base() { }
		public UpdateCourseDomainEvent(Guid id, string title, AgeRangeEnum ageRange, Guid fieldId) : this()
		{
			Id = id;
			Title = title;
			AgeRange = ageRange;
			FieldId = fieldId;
		}

		public Guid Id { get; set; }
		public string Title { get; set; }
		public AgeRangeEnum AgeRange { get; set; }
		public Guid FieldId { get; set; }
	}
}
