using Sofa.CourseManagement.Domain.Shared.ValueObjects;
using Sofa.CourseManagement.SharedKernel.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sofa.CourseManagement.Domain.Institutes.Entities
{
    public class Term : Entity<Guid>
    {
        public Title Title { get; private set; }

        public CorelationId CourseId { get; private set; }
        public Course Course { get; private set; }
        public ICollection<Session> Sessions { get; set; }

        private Term()
        {
            Sessions = new List<Session>();
        }

        public void AssignTitle(string title) { this.Title = title; }
        public void AssignCourse(Guid courseId) { this.CourseId = courseId; }
        public void AssignCourse(Course course) { this.CourseId = course.Id; this.Course = course; }
        public void AssignSessions(IEnumerable<Session> sessions)
        {
            if (this.Sessions.Any())
                this.Sessions.ToList().AddRange(sessions);
            else
                this.Sessions = sessions.ToArray();
        }

        public static Term CreateInstance(Guid id, string title, Guid courseId, bool isActive, string description)
        {
            var term = new Term();

            term.AssignId(id);
            term.AssignTitle(title);
            term.AssignCourse(courseId);

            return term;
        }
    }
}
