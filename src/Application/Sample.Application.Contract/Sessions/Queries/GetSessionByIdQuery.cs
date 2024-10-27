using Sofa.CourseManagement.Application.Contract.Sessions.Dtos;
using Sofa.CourseManagement.Application.Contract.Shared;
using Sofa.CourseManagement.SharedKernel.Application;
using System;

namespace Sofa.CourseManagement.Application.Contract.Sessions.Queries
{
	public class GetSessionByIdQuery : GetByIdQueryBase, IQuery<SessionDto>
	{
		public Guid InstituteId { get; set; }
		public Guid FieldId { get; set; }
		public Guid CourseId { get; set; }
		public Guid TermId { get; set; }
		public GetSessionByIdQuery(Guid instituteId, Guid fieldId, Guid courseId, Guid termId, Guid id) : base(id)
		{
			InstituteId = instituteId;
			FieldId = fieldId;
			CourseId = courseId;
			TermId = termId;
		}
	}
}
