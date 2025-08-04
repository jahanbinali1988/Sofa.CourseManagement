using Sofa.CourseManagement.Domain.Contract.Institutes.Enums;
using Sofa.SharedKernel.EventProcessing.DomainEvent;

namespace Sofa.CourseManagement.Domain.Contract.Institutes.Events.PostQuestions
{
	public class AddPostQuestionDomainEvent : DomainEventBase
	{
		public AddPostQuestionDomainEvent() : base()
		{
			
		}
		public AddPostQuestionDomainEvent(Guid id, PriorityEnum priority, Guid questionId, Guid postId) : this()
		{
			Id = id;
			Priority = priority;
			QuestionId = questionId;
			PostId = postId;
		}

		public Guid Id { get; }
		public PriorityEnum Priority { get; }
		public Guid QuestionId { get; }
		public Guid PostId { get; }
	}
}
