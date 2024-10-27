using Sofa.CourseManagement.Application.Contract.Courses.Dtos;
using Sofa.CourseManagement.Application.Contract.Shared;
using Sofa.CourseManagement.Domain.Institutes.Entities;
using Sofa.CourseManagement.Domain.Institutes;
using Sofa.CourseManagement.SharedKernel.Application;
using System;

namespace Sofa.CourseManagement.Application.Contract.Courses.Queries
{
	public class GetAllCoursesQuery : GetListQueryBase, IQuery<Pagination<CourseDto>>
	{
		public Guid FieldId { get; set; }
		public Guid InstituteId { get; set; }
		public GetAllCoursesQuery(Guid instituteId, Guid fieldId, int offset, int count, string keyword) : base(offset, count, keyword)
		{
			InstituteId = instituteId;
			FieldId = fieldId;
		}
	}
}
