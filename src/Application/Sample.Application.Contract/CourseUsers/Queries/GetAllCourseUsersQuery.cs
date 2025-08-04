using Sofa.CourseManagement.Application.Contract.CourseUsers.Dtos;
using Sofa.CourseManagement.Application.Contract.Shared;
using Sofa.SharedKernel.Application;
using System;

namespace Sofa.CourseManagement.Application.Contract.CourseUsers.Queries
{
	public class GetAllCourseUsersQuery : GetListQueryBase, IQuery<Pagination<CourseUserDto>>
	{
		public GetAllCourseUsersQuery(int offset, int count, string keyword, string userId) : base(offset, count, keyword)
		{
			UserId = userId;
		}

		public GetAllCourseUsersQuery(int offset, int count, string keyword, string instititeId, string fieldId, string courseId) : base(offset, count, keyword)
		{
			InstituteId = instititeId;
			FieldId = fieldId;
			CourseId = courseId;
		}

		public Id? UserId { get; set; }
		public Id? InstituteId { get; set; }
		public Id FieldId { get; }
		public Id CourseId { get; }
	}
}
