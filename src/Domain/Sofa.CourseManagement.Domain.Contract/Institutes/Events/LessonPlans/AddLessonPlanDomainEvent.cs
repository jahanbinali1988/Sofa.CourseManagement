﻿using Sofa.CourseManagement.Domain.Contract.Users.Enums;
using Sofa.CourseManagement.SharedKernel.EventProcessing.DomainEvent;

namespace Sofa.CourseManagement.Domain.Contract.Institutes.Events.LessonPlans
{
    public class AddLessonPlanDomainEvent : DomainEventBase
	{
		public AddLessonPlanDomainEvent() : base()
		{

		}
		public AddLessonPlanDomainEvent(Guid id, string title, Guid sessionId, Guid courseLanguageId) : this()
		{
			Id = id;
			Title = title;
			SessionId = sessionId;
			CourseLanguageId = courseLanguageId;
		}
		public Guid Id { get; set; }
        public string Title { get; set; }
		public Guid SessionId { get; set; }
		public Guid CourseLanguageId { get; }
	}
}
