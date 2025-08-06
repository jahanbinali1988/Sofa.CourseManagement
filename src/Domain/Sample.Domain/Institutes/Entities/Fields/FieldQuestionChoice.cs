using Sofa.CourseManagement.Domain.Contract.Institutes.Events.FieldQuestionChoices;
using Sofa.CourseManagement.Domain.Institutes.ValueObjects;
using Sofa.SharedKernel.SeedWork;
using System;

namespace Sofa.CourseManagement.Domain.Institutes.Entities
{
	public class FieldQuestionChoice : Entity<Guid>
	{
		private FieldQuestionChoice() : base()
		{
			
		}
		private FieldQuestionChoice(Guid id, string content, bool isAnswer, Guid questionId) : this()
		{
			AssignId(id);
			AssignContent(content);
			AssignIsAnswer(isAnswer);
			AssignQuestion(questionId);
		}

		public Content Content { get; private set; }
		public bool IsAnswer { get; private set; }
		public Guid FieldQuestionId { get; private set; }
		public FieldQuestion FieldQuestion { get; private set; }

		private void AssignContent(string content) { this.Content = content; }
		private void AssignIsAnswer(bool isAnswer) { this.IsAnswer = isAnswer; }
		private void AssignQuestion(Guid questionId) { this.FieldQuestionId = questionId; }

		public static FieldQuestionChoice CreateInstance(Guid id, string content, bool isAnswer, Guid questionId, Guid fieldId, Guid instituteId) 
		{
			var instance = new FieldQuestionChoice(id, content, isAnswer, questionId);

			instance.AddDomainEvent(new AddFieldQuestionChoiceDomainEvent(id, content, isAnswer, questionId, fieldId, instituteId));

			return instance;
		}
		public void Delete()
		{
			MarkAsDeleted();
			AddDomainEvent(new DeleteFieldQuestionChoiceDomainEvent(this.Id));
		}
		public void Update(string content, bool isAnswer, Guid questionId, Guid fieldId, Guid instituteId)
		{
			AssignContent(content);
			AssignIsAnswer(isAnswer);
			AssignQuestion(questionId);
			base.MarkAsUpdated();

			AddDomainEvent(new UpdateFieldQuestionChoiceDomainEvent(Id, content, isAnswer, questionId, fieldId, instituteId));
		}
	}
}
