using Sofa.CourseManagement.Application.Contract.Shared;
using Sofa.CourseManagement.Application.Contract.Terms.Dtos;
using Sofa.CourseManagement.SharedKernel.Application;
using System;

namespace Sofa.CourseManagement.Application.Contract.Terms.Queries
{
	public class GetTermByIdQuery : GetByIdQueryBase, IQuery<TermDto>
	{
		public Guid CourseId { get; set; }
		public Guid InstituteId { get; set; }
		public Guid FieldId { get; set; }
		public GetTermByIdQuery(Guid instituteId, Guid fieldId, Guid courseId, Guid id) : base(id)
		{
			CourseId = courseId;
			InstituteId = instituteId;
			FieldId = fieldId;
		}
	}
}
