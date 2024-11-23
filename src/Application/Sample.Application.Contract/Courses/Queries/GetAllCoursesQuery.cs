using Sofa.CourseManagement.Application.Contract.Courses.Dtos;
using Sofa.CourseManagement.Application.Contract.Shared;
using Sofa.CourseManagement.SharedKernel.Application;
using System;

namespace Sofa.CourseManagement.Application.Contract.Courses.Queries
{
	public class GetAllCoursesQuery : GetListQueryBase, IQuery<Pagination<CourseDto>>
	{
		public Id FieldId { get; set; }
		public Id InstituteId { get; set; }
		public GetAllCoursesQuery(string instituteId, string fieldId, int offset, int count, string keyword) : base(offset, count, keyword)
		{
			InstituteId = instituteId;
			FieldId = fieldId;
		}
	}
}
