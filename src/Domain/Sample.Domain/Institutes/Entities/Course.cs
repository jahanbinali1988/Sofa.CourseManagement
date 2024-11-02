using Sofa.CourseManagement.Domain.Contract.Institutes.Enums;
using Sofa.CourseManagement.Domain.Institutes.ValueObjects;
using Sofa.CourseManagement.SharedKernel.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sofa.CourseManagement.Domain.Institutes.Entities
{
    public class Course : Entity<Guid>
	{
		public Title Title { get; private set; }
		public AgeRange AgeRange { get; private set; }
        public Guid FieldId { get; private set; }

        public ICollection<Term> Terms { get; private set; }

		private Course()
        {
            Terms = new List<Term>();

        }

        private void AssignTitle(string title) { this.Title = title; }
		private void AssignAgeRange(AgeRangeEnum ageRange) { this.AgeRange = ageRange; }
		private void AssignFieldId(Guid fieldId) { this.FieldId = fieldId; }

        public static Course CreateInstance(Guid id, string title, AgeRangeEnum ageRange, Guid fieldId)
        {
            var course = new Course();

            course.AssignId(id);
            course.AssignTitle(title);
            course.AssignAgeRange(ageRange);
            course.AssignFieldId(fieldId);

            return course;
        }

		public void Update(string title, AgeRangeEnum ageRange)
		{
			AssignTitle(title);
			AssignAgeRange(ageRange);
		}

		public void AddTerm(Term term)
		{
            Terms.Add(term);
		}

		public void DeleteTerm(Term term)
		{
            Terms.Remove(term);
		}
	}
}
