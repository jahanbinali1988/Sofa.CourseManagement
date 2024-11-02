using Sofa.CourseManagement.Application.Contract.Posts.Dtos;
using Sofa.CourseManagement.Application.Contract.Shared;
using Sofa.CourseManagement.SharedKernel.Application;
using System;

namespace Sofa.CourseManagement.Application.Contract.Posts.Queries
{
	public class GetPostByIdQuery : GetByIdQueryBase, IQuery<PostBaseDto>
	{
		public Guid InstituteId { get; }
		public Guid FieldId { get; }
		public Guid CourseId { get; }
		public Guid TermId { get; }
		public Guid SessionId { get; }
		public Guid LessonPlanId { get; }
		public GetPostByIdQuery(Guid instituteId, Guid fieldId, Guid courseId, Guid termId, Guid sessionId, Guid lessonPlanId, Guid postId) : base(postId)
		{
			InstituteId = instituteId;
			FieldId = fieldId;
			CourseId = courseId;
			TermId = termId;
			SessionId = sessionId;
			LessonPlanId = lessonPlanId;
		}
	}
}
