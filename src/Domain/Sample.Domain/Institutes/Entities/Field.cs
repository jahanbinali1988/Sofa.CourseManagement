using Sofa.CourseManagement.Domain.Contract.Institutes.Events.Fields;
using Sofa.CourseManagement.Domain.Institutes.ValueObjects;
using Sofa.CourseManagement.SharedKernel.SeedWork;
using System;
using System.Collections.Generic;

namespace Sofa.CourseManagement.Domain.Institutes.Entities
{
    public class Field : Entity<Guid>
    {
        public Title Title { get; private set; }
        public Guid InstituteId { get; private set; }

		public Institute Institute { get; private set; }
		private readonly List<Course> _courses;
		public IReadOnlyList<Course> Courses => _courses.AsReadOnly();

		private Field() : base()
        {
			_courses = new List<Course>();
        }

        private void AssignTitle(string title) { this.Title = title; }
		private void AssignInstitute(Guid instituteId) { this.InstituteId = instituteId; }

        public static Field CreateInstance(Guid id, string title, Guid instituteId)
        {
            var field = new Field();

            field.AssignId(id);
            field.AssignTitle(title);
            field.AssignInstitute(instituteId);

            field.AddDomainEvent(new AddFieldDomainEvent(field.Id, field.Title.Value, field.InstituteId));

            return field;
        }

		public void Update(string title)
		{
			AssignTitle(title);
			base.MarkAsUpdated();

			AddDomainEvent(new UpdateFieldDomainEvent(Id, Title.Value, InstituteId));
		}

		public void Delete()
		{
			MarkAsDeleted();
			AddDomainEvent(new DeleteFieldDomainEvent(Id));
		}

		public void AddCourse(Course course)
		{
			_courses.Add(course);
		}

		public void DeleteCourse(Course course)
		{
			_courses.Remove(course);
		}
	}
}
