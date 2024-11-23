using Sofa.CourseManagement.Application.Contract.Posts.Dtos;
using Sofa.CourseManagement.Application.Contract.Shared;
using Sofa.CourseManagement.SharedKernel.Application;
using System;

namespace Sofa.CourseManagement.Application.Contract.Posts.Queries
{
	public class GetAllPostsQuery : GetListQueryBase, IQuery<Pagination<PostBaseDto>>
	{
		public Id InstituteId { get; }
		public Id FieldId { get; }
		public Id CourseId { get; }
		public Id TermId { get; }
		public Id SessionId { get; }
		public Id LessonPlanId { get; }
		public GetAllPostsQuery(string instituteId, string fieldId, string courseId, string termId, string sessionId, string lessonPlanId
			, int offset, int count, string keyword) : base(offset, count, keyword)
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
