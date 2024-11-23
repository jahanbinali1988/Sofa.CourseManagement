using Sofa.CourseManagement.Application.Contract.Shared;
using Sofa.CourseManagement.Application.Contract.Terms.Dtos;
using Sofa.CourseManagement.SharedKernel.Application;
using System;

namespace Sofa.CourseManagement.Application.Contract.Terms.Queries
{
	public class GetAllTermsQuery : GetListQueryBase, IQuery<Pagination<TermDto>>
	{
		public Id CourseId { get; set; }
		public Id InstituteId { get; set; }
		public Id FieldId { get; set; }
		public GetAllTermsQuery(string instituteId, string fieldId, string courseId, int offset, int count, string keyword) : base(offset, count, keyword)
		{
			CourseId = courseId;
			InstituteId = instituteId;
			FieldId = fieldId;
		}
	}
}
