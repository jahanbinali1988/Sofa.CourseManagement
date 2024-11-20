using Sofa.CourseManagement.SharedKernel.EventProcessing.DomainEvent;

namespace Sofa.CourseManagement.Domain.Contract.Institutes.Events.Institutes
{
	public class AddInstituteDomainEvent : DomainEventBase
	{
		public AddInstituteDomainEvent() : base()
		{

		}
		public AddInstituteDomainEvent(Guid id, string title, string websiteUrl, string code) : this()
		{
			Id = id;
			Title = title;
			WebsiteUrl = websiteUrl;
			Code = code;
		}
		public Guid Id { get; set; }
		public string Title { get; set; }
		public string WebsiteUrl { get; set; }
		public string Code { get; set; }
	}
}
