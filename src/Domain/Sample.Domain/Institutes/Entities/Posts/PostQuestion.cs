using Sofa.CourseManagement.Domain.Contract.Institutes.Enums;
using Sofa.CourseManagement.Domain.Contract.Institutes.Events.PostQuestions;
using Sofa.CourseManagement.Domain.Institutes.ValueObjects;
using Sofa.CourseManagement.SharedKernel.SeedWork;
using System;

namespace Sofa.CourseManagement.Domain.Institutes.Entities.Posts
{
	public class PostQuestion : Entity<Guid>
	{
		private PostQuestion() : base()
		{
			
		}
		private PostQuestion(Guid id, PriorityEnum priority, Guid questionId, Guid postId) : this()
		{
			base.AssignId(id);
			AssignPriority(priority);
			AssignQuestion(questionId);
			AssignPost(postId);
		}

		public Priority Priority { get; private set; }
		public Guid QuestionId { get; private set; }
		public FieldQuestion Question { get; private set; }
		public Guid PostId { get; private set; }

		private void AssignPriority(PriorityEnum priority) { this.Priority = priority; }
		private void AssignQuestion(Guid questionId) { this.QuestionId = questionId; }
		private void AssignPost(Guid postId) {  this.PostId = postId; }

		public static PostQuestion CreateInstance(Guid id, PriorityEnum priority, Guid questionId, Guid postId) 
		{
			var instance = new PostQuestion(id, priority, questionId, postId);

			instance.AddDomainEvent(new AddPostQuestionDomainEvent(id, priority, questionId, postId));

			return instance;
		}
		public void Update(PriorityEnum priority, Guid questionId, Guid postId)
		{
			AssignPriority(priority);
			AssignQuestion(questionId);
			AssignPost(postId);
			MarkAsUpdated();

			AddDomainEvent(new UpdatePostQuestionDomainEvent(Id, priority, questionId, postId));
		}
		public void Delete()
		{
			MarkAsDeleted();

			AddDomainEvent(new DeletePostQuestionDomainEvent(Id));
		}
	}
}
