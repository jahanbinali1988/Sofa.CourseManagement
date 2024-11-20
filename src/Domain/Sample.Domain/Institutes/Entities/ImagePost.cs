﻿using Sofa.CourseManagement.Domain.Contract.Institutes.Enums;
using Sofa.CourseManagement.Domain.Contract.Institutes.Events.Posts;
using System;

namespace Sofa.CourseManagement.Domain.Institutes.Entities
{
    public class ImagePost : PostBase
    {
        public ImagePost() : base()
        {
            
        }
        public static ImagePost CreateInstance(Guid id, string title, short order, string content, Guid LessonPlanId)
        {
            var post = new ImagePost();

            post.AssignId(id);
            post.AssignTitle(title);
            post.AssignOrder(order);
            post.AssignContent(content);
            post.AssignLessonPlan(LessonPlanId);

			post.AddDomainEvent(new AddImagePostDomainEvent(post.Id, post.Title.Value, post.Order, post.Content.Value, post.ContentType.Value, post.LessonPlanId));

			return post;
		}

		public override void Delete()
		{
			MarkAsDeleted();
			AddDomainEvent(new DeleteImagePostDomainEvent(Id));
		}

		public override void Update(string title, string content, ContentTypeEnum contentType, short order)
		{
			AssignTitle(title);
			AssignContent(content);
			AssignContentType(contentType);
			AssignOrder(order);
			base.MarkAsUpdated();

			AddDomainEvent(new UpdateImagePostDomainEvent(Id, Title.Value, Order, Content.Value, ContentType.Value, LessonPlanId));
		}
	}
}
