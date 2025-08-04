using Sofa.CourseManagement.Application.Contract.Fields.Dtos;
using Sofa.CourseManagement.Application.Contract.Shared;
using Sofa.SharedKernel.Application;
using System;

namespace Sofa.CourseManagement.Application.Contract.Fields.Queries
{
	public class GetFieldByIdQuery : GetByIdQueryBase, IQuery<FieldDto>
	{
        public Id InstituteId { get; set; }
        public GetFieldByIdQuery(string instituteId, string id) : base(id)
		{
			InstituteId = instituteId;
		}
	}
}
