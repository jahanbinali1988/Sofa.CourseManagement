using Sofa.CourseManagement.Application.Contract.Posts.Dtos;
using Sofa.CourseManagement.Application.Contract.Shared;
using Sofa.CourseManagement.SharedKernel.Application;
using System;

namespace Sofa.CourseManagement.Application.Contract.Posts.Queries
{
	public class GetPostByIdQuery : GetByIdQueryBase, IQuery<PostBaseDto>
	{
		public GetPostByIdQuery(Guid lessonpalnId, Guid id) : base(id)
		{
			LessonpalnId = lessonpalnId;
		}

		public Guid LessonpalnId { get; }
	}
}
