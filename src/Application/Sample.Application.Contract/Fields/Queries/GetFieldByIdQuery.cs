using Sofa.CourseManagement.Application.Contract.Fields.Dtos;
using Sofa.CourseManagement.Application.Contract.Shared;
using Sofa.CourseManagement.SharedKernel.Application;
using System;

namespace Sofa.CourseManagement.Application.Contract.Fields.Queries
{
	public class GetFieldByIdQuery : GetByIdQueryBase, IQuery<FieldDto>
	{
        public Guid InstituteId { get; set; }
        public GetFieldByIdQuery(Guid instituteId, Guid id) : base(id)
		{
			InstituteId = instituteId;
		}
	}
}
