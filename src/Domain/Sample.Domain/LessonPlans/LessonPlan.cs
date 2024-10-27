﻿using Sofa.CourseManagement.Domain.Contract.Institutes.Enums;
using Sofa.CourseManagement.Domain.Institutes.Entities;
using Sofa.CourseManagement.Domain.LessonPlans.Entities;
using Sofa.CourseManagement.Domain.LessonPlans.ValueObjects;
using Sofa.CourseManagement.Domain.Shared.ValueObjects;
using Sofa.CourseManagement.SharedKernel.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sofa.CourseManagement.Domain.LessonPlans
{
    public class LessonPlan : Entity<Guid>, IAggregateRoot
	{
        public Title Title { get; private set; }
        public LessonPlanLevel Level { get; private set; }

        public CorelationId SessionId { get; private set; }
        public Session Session { get; private set; }
        public ICollection<PostBase> Posts { get; set; }

        private LessonPlan()
        {
            Posts = new List<PostBase>();
        }

		public void AssignTitle(string title) { Title = title; }
		public void AssignLevel(LevelEnum level) { Level = level; }
        public void AssignSession(Guid sessionId) { SessionId = sessionId; }
        public void AssignSession(Session session) { SessionId = session.Id; Session = session; }
        public void AssignPosts(IEnumerable<PostBase> posts)
        {
            if (Posts.Any())
                Posts.ToList().AddRange(posts);
            else
                Posts = posts.ToArray();
        }

        public static LessonPlan CreateInstance(Guid id, string title, LevelEnum level, Guid sessionId, bool isActive, string description)
        {
            var lessonPlan = new LessonPlan();

            lessonPlan.AssignTitle(title);
            lessonPlan.AssignId(id);
            lessonPlan.AssignLevel(level);
            lessonPlan.AssignSession(sessionId);

            return lessonPlan;
        }
    }
}
