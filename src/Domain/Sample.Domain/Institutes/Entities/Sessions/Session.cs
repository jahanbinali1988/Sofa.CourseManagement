using Sofa.CourseManagement.Domain.Contract.Institutes.Events.Sessions;
using Sofa.CourseManagement.Domain.Institutes.Entities.Courses;
using Sofa.CourseManagement.Domain.Institutes.Entities.LessonPlans;
using Sofa.CourseManagement.Domain.Institutes.ValueObjects;
using Sofa.SharedKernel.SeedWork;
using System;
using System.Collections.Generic;

namespace Sofa.CourseManagement.Domain.Institutes.Entities.Sessions
{
	public class Session : Entity<Guid>
	{
		public Title Title { get; private set; }
		public OccurredDate OccurredDate { get; private set; }
		
		public Guid CourseId { get; private set; }
		public Course Course { get; private set; }

		public IReadOnlyCollection<LessonPlan> LessonPlans => _lessonPlans.AsReadOnly();
		private readonly List<LessonPlan> _lessonPlans;

		private Session() : base()
		{
			_lessonPlans = new List<LessonPlan>();
		}
		private Session(Guid id, string title, DateTimeOffset occrredDate, Guid courseId) : this()
		{
			AssignId(id);
			AssignTitle(title);
			AssignOccurredDate(occrredDate);
			AssignCourseId(courseId);
		}

		private void AssignTitle(string title) { Title = title; }
		private void AssignCourseId(Guid courseId) { this.CourseId = courseId; }
		private void AssignOccurredDate(DateTimeOffset occurredDate) { OccurredDate = occurredDate; }

		public static Session CreateInstance(Guid id, string title, Guid courseId, DateTimeOffset occurredDate)
		{
			var session = new Session(id, title, occurredDate, courseId);

			session.AddDomainEvent(new AddSessionDomainEvent(session.Id, session.Title.Value, session.OccurredDate.Value, session.CourseId));

			return session;
		}
		public void Update(string title, DateTimeOffset occurredDate)
		{
			AssignTitle(title);
			AssignOccurredDate(occurredDate);
			MarkAsUpdated();

			AddDomainEvent(new UpdateSessionDomainEvent(Id, Title.Value, OccurredDate.Value, CourseId));
		}
		public void Delete()
		{
			MarkAsDeleted();
			AddDomainEvent(new DeleteSessionDomainEvent(Id));
		}
		public void AddLessonPlan(LessonPlan lessonplan)
		{
			_lessonPlans.Add(lessonplan);
		}
		public void DeleteLessonPlan(LessonPlan lessonplan)
		{
			_lessonPlans.Remove(lessonplan);
		}
	}
}
