using Sofa.CourseManagement.Application.Contract.Posts.Dtos;
using Sofa.CourseManagement.Application.Contract.Shared;
using Sofa.CourseManagement.SharedKernel.Application;
using System;

namespace Sofa.CourseManagement.Application.Contract.Posts.Queries
{
	public class GetAllPostsQuery : GetListQueryBase, IQuery<Pagination<PostBaseDto>>
	{
		public GetAllPostsQuery(Guid lessonpalnId, int offset, int count, string keyword) : base(offset, count, keyword)
		{
			LessonpalnId = lessonpalnId;
		}

		public Guid LessonpalnId { get; }
	}
}
