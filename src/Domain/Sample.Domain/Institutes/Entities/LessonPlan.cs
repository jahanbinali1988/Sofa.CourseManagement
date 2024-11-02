using Sofa.CourseManagement.Domain.Contract.Institutes.Enums;
using Sofa.CourseManagement.Domain.Institutes.ValueObjects;
using Sofa.CourseManagement.SharedKernel.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sofa.CourseManagement.Domain.Institutes.Entities
{
    public class LessonPlan : Entity<Guid>
    {
        public Title Title { get; private set; }
        public LessonPlanLevel Level { get; private set; }

        public Guid SessionId { get; private set; }
        public ICollection<PostBase> Posts { get; private set; }

        private LessonPlan()
        {
            Posts = new List<PostBase>();
        }

        private void AssignTitle(string title) { Title = title; }
		private void AssignLevel(LevelEnum level) { Level = level; }
		private void AssignSession(Guid sessionId) { SessionId = sessionId; }

        public static LessonPlan CreateInstance(Guid id, string title, LevelEnum level, Guid sessionId)
        {
            var lessonPlan = new LessonPlan();

            lessonPlan.AssignTitle(title);
            lessonPlan.AssignId(id);
            lessonPlan.AssignLevel(level);
            lessonPlan.AssignSession(sessionId);

            return lessonPlan;
        }

		public void Update(string title, LevelEnum level)
		{
			AssignTitle(title);
			AssignLevel(level);
		}

		public void AddPost(PostBase post)
		{
            Posts.Add(post);
		}

		public void DeletePost(PostBase post)
		{
            Posts.Remove(post);
		}
	}
}
