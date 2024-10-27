using Sofa.CourseManagement.Domain.Shared.ValueObjects;
using Sofa.CourseManagement.SharedKernel.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sofa.CourseManagement.Domain.Institutes.Entities
{
    public class Field : Entity<Guid>
    {
        public Title Title { get; private set; }

        public CorelationId InstituteId { get; private set; }
        public Institute Institute { get; private set; }
        public ICollection<Course> Courses { get; set; }

        private Field()
        {
            Courses = new List<Course>();
        }

        public void AssignTitle(string title) { this.Title = title; }
        public void AssignInstitute(Guid instituteId) { this.InstituteId = instituteId; }
        public void AssignInstitute(Institute institute) { this.InstituteId = institute.Id; this.Institute = institute; }
        public void AssignCourses(IEnumerable<Course> courses)
        {
            if (Courses.Any())
                this.Courses.ToList().AddRange(courses);
            else
                this.Courses = courses.ToArray();
        }

        public static Field CreateInstance(Guid id, string title, Guid instituteId, bool isActive, string description)
        {
            var field = new Field();

            field.AssignId(id);
            field.AssignTitle(title);
            field.AssignInstitute(instituteId);

            return field;
        }
    }
}
