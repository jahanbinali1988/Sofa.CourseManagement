using Sofa.CourseManagement.Application.Contract.LessonPlans.Dtos;
using Sofa.CourseManagement.Application.Contract.Shared;
using Sofa.SharedKernel.Application;

namespace Sofa.CourseManagement.Application.Contract.LessonPlans.Queries
{
	public class GetLessonPlanByIdQuery : GetByIdQueryBase, IQuery<LessonPlanDto>
	{
		public Id InstituteId { get; }
		public Id FieldId { get; }
		public Id CourseId { get; }
		public Id SessionId { get; }
        public GetLessonPlanByIdQuery(string instituteId, string fieldId, string courseId, string sessionId, string lessonplanId) : base(lessonplanId)
		{
			InstituteId = instituteId;
			FieldId = fieldId;
			CourseId = courseId;
			SessionId = sessionId;
		}
	}
}
