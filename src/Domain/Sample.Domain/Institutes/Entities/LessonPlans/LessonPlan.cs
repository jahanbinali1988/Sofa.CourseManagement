﻿using Sofa.CourseManagement.Domain.Contract.Institutes.Events.LessonPlans;
using Sofa.CourseManagement.Domain.Institutes.Entities.Courses;
using Sofa.CourseManagement.Domain.Institutes.Entities.Posts;
using Sofa.CourseManagement.Domain.Institutes.Entities.Sessions;
using Sofa.CourseManagement.Domain.Institutes.ValueObjects;
using Sofa.CourseManagement.SharedKernel.SeedWork;
using System;
using System.Collections.Generic;

namespace Sofa.CourseManagement.Domain.Institutes.Entities.LessonPlans
{
	public class LessonPlan : Entity<Guid>
	{
		public Title Title { get; private set; }

		public Guid SessionId { get; private set; }
		public Session Session { get; private set; }
		public Guid CourseLanguageId { get; private set; }
		public CourseLanguage CourseLanguage { get; private set; }

		public IReadOnlyCollection<PostBase> Posts => _posts.AsReadOnly();
		private readonly List<PostBase> _posts;

		private LessonPlan() : base()
		{
			_posts = new List<PostBase>();
		}
		public LessonPlan(Guid id, string title, Guid sessionId, Guid courseLanguageId) : this()
		{
			AssignId(id);
			AssignTitle(title);
			AssignSession(sessionId);
			AssignLanguage(courseLanguageId);
		}

		private void AssignTitle(string title) { Title = title; }
		private void AssignSession(Guid sessionId) { SessionId = sessionId; }
		private void AssignLanguage(Guid courseLanguageId) { CourseLanguageId = courseLanguageId; }

		public static LessonPlan CreateInstance(Guid id, string title, Guid sessionId, Guid courseLanguageId)
		{
			var lessonPlan = new LessonPlan(id, title, sessionId, courseLanguageId);

			lessonPlan.AddDomainEvent(new AddLessonPlanDomainEvent(lessonPlan.Id, lessonPlan.Title.Value, lessonPlan.SessionId, lessonPlan.CourseLanguageId));

			return lessonPlan;
		}
		public void Update(string title)
		{
			AssignTitle(title);
			MarkAsUpdated();

			AddDomainEvent(new UpdateLessonPlanDomainEvent(Id, title, SessionId, CourseLanguageId));
		}
		public void Delete()
		{
			MarkAsDeleted();
			AddDomainEvent(new DeleteLessonPlanDomainEvent(Id));
		}
		public void AddPost(PostBase post)
		{
			_posts.Add(post);
		}
		public void DeletePost(PostBase post)
		{
			_posts.Remove(post);
		}
	}
}
