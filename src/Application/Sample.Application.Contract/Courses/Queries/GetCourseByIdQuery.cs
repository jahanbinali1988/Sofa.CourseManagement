using Sofa.CourseManagement.Application.Contract.Courses.Dtos;
using Sofa.CourseManagement.Application.Contract.Shared;
using Sofa.CourseManagement.SharedKernel.Application;
using System;

namespace Sofa.CourseManagement.Application.Contract.Courses.Queries
{
	public class GetCourseByIdQuery : GetByIdQueryBase, IQuery<CourseDto>
	{
		public Guid FieldId { get; set; }
		public Guid InstituteId { get; set; }
		public GetCourseByIdQuery(Guid instituteId, Guid fieldId, Guid id) : base(id)
		{
			InstituteId = instituteId; 
			FieldId = fieldId;
		}
	}
}
