using Sofa.CourseManagement.Domain.Contract.Institutes.Enums;
using Sofa.CourseManagement.Domain.Contract.Institutes.Events.Courses;
using Sofa.CourseManagement.Domain.Institutes.Entities.Sessions;
using Sofa.CourseManagement.Domain.Institutes.ValueObjects;
using Sofa.CourseManagement.SharedKernel.SeedWork;
using System;
using System.Collections.Generic;

namespace Sofa.CourseManagement.Domain.Institutes.Entities.Courses
{
	public class Course : Entity<Guid>
	{
		public Title Title { get; private set; }
		public AgeRange AgeRange { get; private set; }

		public Guid FieldId { get; private set; }
		public Field Field { get; private set; }

		public IReadOnlyList<Session> Sessions => _sessions.AsReadOnly();
		public readonly List<Session> _sessions;
		public IReadOnlyList<CourseLanguage> CourseLanguages => _courseLanguages.AsReadOnly();
		public readonly List<CourseLanguage> _courseLanguages;
		public IReadOnlyList<CoursePlacement> Placements => _placements.AsReadOnly();
		public readonly List<CoursePlacement> _placements;
		public IReadOnlyList<CourseUser> CourseUsers => _courseUsers.AsReadOnly();
		private readonly List<CourseUser> _courseUsers;

		private Course() : base()
		{
			_sessions = new List<Session>();
			_courseLanguages = new List<CourseLanguage>();
			_placements = new List<CoursePlacement>();
			_courseUsers = new List<CourseUser>();
		}
		private Course(Guid id, string title, AgeRangeEnum ageRange, Guid fieldId) : this()
		{
			AssignId(id);
			AssignTitle(title);
			AssignAgeRange(ageRange);
			AssignFieldId(fieldId);
		}

		private void AssignTitle(string title) { Title = title; }
		private void AssignAgeRange(AgeRangeEnum ageRange) { AgeRange = ageRange; }
		private void AssignFieldId(Guid fieldId) { FieldId = fieldId; }

		public static Course CreateInstance(Guid id, string title, AgeRangeEnum ageRange, Guid fieldId)
		{
			var course = new Course(id, title, ageRange, fieldId);

			course.AddDomainEvent(new AddCourseDomainEvent(course.Id, course.Title.Value, course.AgeRange.Value, course.FieldId));

			return course;
		}
		public void Update(string title, AgeRangeEnum ageRange)
		{
			AssignTitle(title);
			AssignAgeRange(ageRange);
			MarkAsUpdated();

			AddDomainEvent(new UpdateCourseDomainEvent(Id, Title.Value, AgeRange.Value, FieldId));
		}
		public void Delete()
		{
			MarkAsDeleted();
			AddDomainEvent(new DeleteCourseDomainEvent(Id));
		}
		public void AddSession(Session session)
		{
			_sessions.Add(session);
		}
		public void DeleteSession(Session session)
		{
			_sessions.Remove(session);
		}
		public void AddLanguage(CourseLanguage language)
		{
			_courseLanguages.Add(language);
		}
		public void DeleteLanguage(CourseLanguage language)
		{
			_courseLanguages.Remove(language);
		}
		public void AddUser(CourseUser courseUser)
		{
			_courseUsers.Add(courseUser);
		}
		public void DeleteUser(CourseUser courseUser)
		{
			_courseUsers.Remove(courseUser);
		}

		public void AddPlacement(CoursePlacement coursePlacement)
		{
			_placements.Add(coursePlacement);
		}
		public void DeletePlacement(CoursePlacement coursePlacement)
		{
			_placements.Remove(coursePlacement);
		}
	}
}
