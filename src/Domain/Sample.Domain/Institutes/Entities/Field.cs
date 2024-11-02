using Sofa.CourseManagement.SharedKernel.SeedWork;
using System;
using System.Collections.Generic;

namespace Sofa.CourseManagement.Domain.Institutes.Entities
{
    public class Field : Entity<Guid>
    {
        public Title Title { get; private set; }

        public Guid InstituteId { get; private set; }
        public ICollection<Course> Courses { get; set; }

        private Field()
        {
            Courses = new List<Course>();
        }

        private void AssignTitle(string title) { this.Title = title; }
		private void AssignInstitute(Guid instituteId) { this.InstituteId = instituteId; }

        public static Field CreateInstance(Guid id, string title, Guid instituteId)
        {
            var field = new Field();

            field.AssignId(id);
            field.AssignTitle(title);
            field.AssignInstitute(instituteId);

            return field;
        }

		public void Update(string title)
		{
			AssignTitle(title);
		}

		public void AddCourse(Course course)
		{
            Courses.Add(course);
		}

		public void Delete(Course course)
		{
            Courses.Remove(course);
		}
	}
}
