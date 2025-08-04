using Sofa.CourseManagement.Domain.Contract.Institutes.Events.CoursePlacementQuestions;
using Sofa.CourseManagement.Domain.Institutes.ValueObjects;
using Sofa.SharedKernel.SeedWork;
using System;

namespace Sofa.CourseManagement.Domain.Institutes.Entities.Courses
{
	public class CoursePlacementQuestion : Entity<Guid>
	{
		private CoursePlacementQuestion() : base()
		{
			
		}
		private CoursePlacementQuestion(Guid id, short order, Guid placementId, Guid questionId) : this()
		{
			base.AssignId(id);
			AssignOrder(order);
			AssignPlacement(placementId);
			AssignQuestion(questionId);
		}

		public OrderNumber Order { get; private set; }
		public Guid PlacementId { get; private set; }
		public CoursePlacement CoursePlacement { get; private set; }
		public Guid QuestionId { get; private set; }
		public FieldQuestion Question { get; private set; }

		private void AssignOrder(short order) { this.Order = order; }
		private void AssignPlacement(Guid placementId) { this.PlacementId = placementId; }
		private void AssignQuestion(Guid questionId) { this.QuestionId = questionId; }

		public static CoursePlacementQuestion CreateInstance(Guid id, short order, Guid placementId, Guid questionId)
		{
			var instance = new CoursePlacementQuestion(id, order, placementId, questionId);

			instance.AddDomainEvent(new AddCoursePlacementQuestionDomainEvent(id, order, placementId, questionId));

			return instance;
		}
		public void Update(short order, Guid placementId, Guid questionId)
		{
			AssignOrder(order);
			AssignPlacement(placementId);
			AssignQuestion(questionId);
			MarkAsUpdated();
			
			AddDomainEvent(new UpdateCoursePlacementQuestionDomainEvent(Id, order, placementId, questionId));
		}
		public void Delete()
		{
			MarkAsDeleted();
			
			AddDomainEvent(new DeleteCoursePlacementQuestionDomainEvent(Id));

		}
	}
}
