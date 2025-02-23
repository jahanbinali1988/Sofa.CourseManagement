using Sofa.CourseManagement.Domain.Contract.Institutes.Events.CoursePlacements;
using Sofa.CourseManagement.Domain.Institutes.ValueObjects;
using Sofa.CourseManagement.SharedKernel.SeedWork;
using System;
using System.Collections.Generic;

namespace Sofa.CourseManagement.Domain.Institutes.Entities.Courses
{
	public class CoursePlacement : Entity<Guid>
	{
		private CoursePlacement() : base()
		{
			_questions = new List<CoursePlacementQuestion>();
		}
		private CoursePlacement(Guid id, string title, Guid courseId) : this()
		{
			base.AssignId(id);
			AssignTitle(title);
			AssignCourse(courseId);
		}

		public Title Title { get; private set; }

		public Guid CourseId { get; private set; }
		public Course Course { get; private set; }

		public IReadOnlyCollection<CoursePlacementQuestion> Questions => _questions.AsReadOnly();
		public List<CoursePlacementQuestion> _questions { get; private set; }

		private void AssignTitle(string title) { this.Title = title; }
		private void AssignCourse(Guid courseId) { this.CourseId = courseId; }

		public static CoursePlacement CreateInstance(Guid id, string title, Guid courseId)
		{
			var instance = new CoursePlacement(id, title, courseId);

			instance.AddDomainEvent(new AddCoursePlacementDomainEvent(id, title, courseId));

			return instance;
		} 
		public void Update(string title, Guid courseId)
		{
			base.MarkAsUpdated();
			base.AddDomainEvent(new UpdateCoursePlacementDomainEvent(Id, title, courseId));
		}
		public void Delete()
		{
			base.MarkAsDeleted();
			base.AddDomainEvent(new DeleteCoursePlacementDomainEvent(Id));
		}
		public void AddQuestion(CoursePlacementQuestion question)
		{
			_questions.Add(question);
		}
		public void DeleteQuestion(CoursePlacementQuestion question)
		{
			_questions.Remove(question);
		}
	}
}
