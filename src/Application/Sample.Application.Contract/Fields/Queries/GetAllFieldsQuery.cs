using Sofa.CourseManagement.Application.Contract.Fields.Dtos;
using Sofa.CourseManagement.Application.Contract.Shared;
using Sofa.CourseManagement.SharedKernel.Application;
using System;

namespace Sofa.CourseManagement.Application.Contract.Fields.Queries
{
	public class GetAllFieldsQuery : GetListQueryBase, IQuery<Pagination<FieldDto>>
	{
		public Guid InstituteId { get; set; }
		public GetAllFieldsQuery(Guid instituteId, int offset, int count, string keyword) : base(offset, count, keyword)
		{
			InstituteId = instituteId;
		}
	}
}
