using Sofa.CourseManagement.Application.Contract.Shared;
using Sofa.CourseManagement.Application.Contract.Terms.Dtos;
using Sofa.CourseManagement.SharedKernel.Application;
using System;

namespace Sofa.CourseManagement.Application.Contract.Terms.Queries
{
	public class GetAllTermsQuery : GetListQueryBase, IQuery<Pagination<TermDto>>
	{
		public Guid CourseId { get; set; }
		public Guid InstituteId { get; set; }
		public Guid FieldId { get; set; }
		public GetAllTermsQuery(Guid instituteId, Guid fieldId, Guid courseId, int offset, int count, string keyword) : base(offset, count, keyword)
		{
			CourseId = courseId;
			InstituteId = instituteId;
			FieldId = fieldId;
		}
	}
}
