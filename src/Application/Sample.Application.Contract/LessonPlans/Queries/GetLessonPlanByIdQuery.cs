using Sofa.CourseManagement.Application.Contract.LessonPlans.Dtos;
using Sofa.CourseManagement.Application.Contract.Shared;
using Sofa.CourseManagement.SharedKernel.Application;
using System;

namespace Sofa.CourseManagement.Application.Contract.LessonPlans.Queries
{
	public class GetLessonPlanByIdQuery : GetByIdQueryBase, IQuery<LessonPlanDto>
	{
		public Guid InstituteId { get; }
		public Guid FieldId { get; }
		public Guid CourseId { get; }
		public Guid TermId { get; }
		public Guid SessionId { get; }
        public GetLessonPlanByIdQuery(Guid instituteId, Guid fieldId, Guid courseId, Guid termId, Guid sessionId, Guid lessonplanId) : base(lessonplanId)
		{
			InstituteId = instituteId;
			FieldId = fieldId;
			CourseId = courseId;
			TermId = termId;
			SessionId = sessionId;
		}
	}
}
