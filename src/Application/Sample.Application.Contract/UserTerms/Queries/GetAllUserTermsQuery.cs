using Sofa.CourseManagement.Application.Contract.Shared;
using Sofa.CourseManagement.Application.Contract.UserTerms.Dtos;
using Sofa.CourseManagement.SharedKernel.Application;
using System;

namespace Sofa.CourseManagement.Application.Contract.UserTerms.Queries
{
	public class GetAllUserTermsQuery : GetListQueryBase, IQuery<Pagination<UserTermDto>>
	{
		public GetAllUserTermsQuery(int offset, int count, string keyword, Guid? userId) : base(offset, count, keyword)
		{
			UserId = userId;
		}

		public GetAllUserTermsQuery(int offset, int count, string keyword, Guid? instititeId, Guid fieldId, Guid courseId, Guid termId) : base(offset, count, keyword)
		{
			InstituteId = instititeId;
			FieldId = fieldId;
			CourseId = courseId;
			TermId = termId;
		}

		public Guid? UserId { get; set; }
		public Guid? InstituteId { get; set; }
		public Guid? TermId { get; set; }
		public Guid FieldId { get; }
		public Guid CourseId { get; }
	}
}
