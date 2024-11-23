using Sofa.CourseManagement.Application.Contract.Shared;
using Sofa.CourseManagement.Application.Contract.Terms.Dtos;
using Sofa.CourseManagement.SharedKernel.Application;
using System;

namespace Sofa.CourseManagement.Application.Contract.Terms.Queries
{
	public class GetTermByIdQuery : GetByIdQueryBase, IQuery<TermDto>
	{
		public Id CourseId { get; set; }
		public Id InstituteId { get; set; }
		public Id FieldId { get; set; }
		public GetTermByIdQuery(string instituteId, string fieldId, string courseId, string id) : base(id)
		{
			CourseId = courseId;
			InstituteId = instituteId;
			FieldId = fieldId;
		}
	}
}
