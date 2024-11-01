﻿using Sofa.CourseManagement.Domain.Contract.Institutes.Enums;
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
        public ICollection<Term> Terms { get; set; }

		private Course()
        {
            Terms = new List<Term>();

        }

        public void AssignTitle(string title) { this.Title = title; }
        public void AssignAgeRange(AgeRangeEnum ageRange) { this.AgeRange = ageRange; }
        public void AssignField(Guid fieldId) { this.FieldId = fieldId; }
        public void AssignTerms(IEnumerable<Term> terms)
        {
            if (Terms.Any())
                this.Terms.ToList().AddRange(terms);
            else
                this.Terms = terms.ToArray();
        }

        public static Course CreateInstance(Guid id, string title, AgeRangeEnum ageRange, Guid fieldId, bool isActive, string description)
        {
            var course = new Course();

            course.AssignId(id);
            course.AssignTitle(title);
            course.AssignAgeRange(ageRange);
            course.AssignField(fieldId);

            return course;
        }
    }
}
