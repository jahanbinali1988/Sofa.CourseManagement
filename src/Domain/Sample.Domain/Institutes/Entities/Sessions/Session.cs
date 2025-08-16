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
		public byte Order { get; private set; }
		
		public Guid CourseId { get; private set; }
		public Course Course { get; private set; }

		public IReadOnlyCollection<LessonPlan> LessonPlans => _lessonPlans.AsReadOnly();
		private readonly List<LessonPlan> _lessonPlans;

		private Session() : base()
		{
			_lessonPlans = new List<LessonPlan>();
		}
		private Session(Guid id, string title, byte order, Guid courseId) : this()
		{
			AssignId(id);
			AssignTitle(title);
			AssignOrder(order);
			AssignCourseId(courseId);
		}

		private void AssignTitle(string title) { Title = title; }
		private void AssignCourseId(Guid courseId) { this.CourseId = courseId; }
		private void AssignOrder(byte order) { Order = order; }

		public static Session CreateInstance(Guid id, string title, Guid courseId, byte order, Guid fieldId, Guid instituteId)
		{
			var session = new Session(id, title, order, courseId);

			session.AddDomainEvent(new AddSessionDomainEvent(session.Id, session.Title.Value, session.Order, session.CourseId, fieldId, instituteId));

			return session;
		}
		public void Update(string title, byte order, Guid fieldId, Guid instituteId)
		{
			AssignTitle(title);
			AssignOrder(order);
			MarkAsUpdated();

			AddDomainEvent(new UpdateSessionDomainEvent(Id, Title.Value, order, CourseId, fieldId, instituteId));
		}
		public void Delete(Guid fieldId, Guid instituteId)
		{
			MarkAsDeleted();
			AddDomainEvent(new DeleteSessionDomainEvent(Id, CourseId, fieldId, instituteId));
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
