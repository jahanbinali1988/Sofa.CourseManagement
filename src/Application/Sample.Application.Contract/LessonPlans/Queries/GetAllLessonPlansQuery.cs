using Sofa.CourseManagement.Application.Contract.Fields.Dtos;
using Sofa.CourseManagement.Application.Contract.LessonPlans.Dtos;
using Sofa.CourseManagement.Application.Contract.Shared;
using Sofa.CourseManagement.SharedKernel.Application;

namespace Sofa.CourseManagement.Application.Contract.LessonPlans.Queries
{
	public class GetAllLessonPlansQuery : GetListQueryBase, IQuery<Pagination<LessonPlanDto>>
	{
		public Id InstituteId { get; set; }
		public Id FieldId { get; set; }
		public Id CourseId { get; set; }
		public Id TermId { get; set; }
        public Id SessionId { get; set; }
        public GetAllLessonPlansQuery(string instituteId, string fieldId, string courseId, string termId, string sessionId, 
			int offset, int count, string keyword) : base(offset, count, keyword)
		{
			InstituteId = instituteId;
			FieldId = fieldId;
			CourseId = courseId;
			TermId = termId;
			SessionId = sessionId;
		}
	}
}
