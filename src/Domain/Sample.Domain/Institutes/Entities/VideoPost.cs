using Sofa.CourseManagement.Domain.Contract.Institutes.Enums;
using System;

namespace Sofa.CourseManagement.Domain.Institutes.Entities
{
    public class VideoPost : PostBase
    {
        public static VideoPost CreateInstance(Guid id, string title, short order, string content, Guid LessonPlanId)
        {
            var post = new VideoPost();

            post.AssignId(id);
            post.AssignTitle(title);
            post.AssignOrder(order);
            post.AssignContent(content);
            post.AssignLessonPlan(LessonPlanId);

            return post;
		}

		public override void Update(string title, string content, ContentTypeEnum contentType, short order)
		{
			AssignTitle(title);
			AssignContent(content);
			AssignContentType(contentType);
			AssignOrder(order);
		}
	}
}
