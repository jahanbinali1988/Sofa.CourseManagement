using Sofa.CourseManagement.Domain.Contract.Institutes.Events.Terms;
using Sofa.CourseManagement.Domain.Contract.Institutes.Events.UserTerms;
using Sofa.CourseManagement.Domain.Institutes.ValueObjects;
using Sofa.CourseManagement.SharedKernel.SeedWork;
using System;
using System.Collections.Generic;

namespace Sofa.CourseManagement.Domain.Institutes.Entities
{
    public class Term : Entity<Guid>
	{
		public Title Title { get; private set; }
		public Guid CourseId { get; private set; }

		public ICollection<Session> Sessions { get; private set; }
		public ICollection<UserTerm> UserTerms { get; private set; }

		private Term() : base()
		{
			Sessions = new List<Session>();
			UserTerms = new List<UserTerm>();
		}

		private void AssignTitle(string title) { this.Title = title; }
		private void AssignCourse(Guid courseId) { this.CourseId = courseId; }

		public static Term CreateInstance(Guid id, string title, Guid courseId)
		{
			var term = new Term();

			term.AssignId(id);
			term.AssignTitle(title);
			term.AssignCourse(courseId);

			term.AddDomainEvent(new AddTermDomainEvent(term.Id, term.Title.Value, term.CourseId));

			return term;
		}
		public void Update(string title)
		{
			AssignTitle(title);
			base.MarkAsUpdated();

			AddDomainEvent(new UpdateTermDomainEvent(Id, Title.Value, CourseId));
		}
		public void Delete()
		{
			MarkAsDeleted();
			AddDomainEvent(new DeleteTermDomainEvent(Id));
		}
		public void AddSession(Session session)
		{
			Sessions.Add(session);
		}
		public void DeleteSession(Session session)
		{
			Sessions.Remove(session);
		}
		public void AddUser(UserTerm userTerm)
		{
			UserTerms.Add(userTerm);
		}
		public void DeleteUser(UserTerm userTerm)
		{
			UserTerms.Remove(userTerm);
		}
	}
}
