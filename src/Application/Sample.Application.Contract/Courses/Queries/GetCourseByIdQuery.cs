using Sofa.CourseManagement.Application.Contract.Courses.Dtos;
using Sofa.CourseManagement.Application.Contract.Shared;
using Sofa.CourseManagement.SharedKernel.Application;
using System;

namespace Sofa.CourseManagement.Application.Contract.Courses.Queries
{
	public class GetCourseByIdQuery : GetByIdQueryBase, IQuery<CourseDto>
	{
		public Id FieldId { get; set; }
		public Id InstituteId { get; set; }
		public GetCourseByIdQuery(string instituteId, string fieldId, string id) : base(id)
		{
			InstituteId = instituteId; 
			FieldId = fieldId;
		}
	}
}
