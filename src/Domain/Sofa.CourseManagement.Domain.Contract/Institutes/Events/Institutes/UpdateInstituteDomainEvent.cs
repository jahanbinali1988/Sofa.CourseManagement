using Sofa.SharedKernel.EventProcessing.DomainEvent;

namespace Sofa.CourseManagement.Domain.Contract.Institutes.Events.Institutes
{
	public class UpdateInstituteDomainEvent : DomainEventBase
	{
		public UpdateInstituteDomainEvent() : base()
		{

		}
		public UpdateInstituteDomainEvent(Guid id, string title, string websiteUrl, string address, string code) : this()
		{
			Id = id;
			Title = title;
			WebsiteUrl = websiteUrl;
			Address = address;
			Code = code;
		}
		public Guid Id { get; set; }
		public string Title { get; set; }
		public string WebsiteUrl { get; set; }
		public string Address { get; set; }
		public string Code { get; set; }
	}
}
