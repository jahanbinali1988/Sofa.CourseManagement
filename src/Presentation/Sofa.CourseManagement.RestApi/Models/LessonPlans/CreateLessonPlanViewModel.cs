using Sofa.CourseManagement.Application.Contract.LessonPlans.Commands;
using Sofa.CourseManagement.Domain.Contract.Users.Enums;

namespace Sofa.CourseManagement.RestApi.Models.LessonPlans
{
    public class CreateLessonPlanViewModel : ViewModelBase
	{
		public string InstituteId { get; }
		public string FieldId { get; }
		public string CourseId { get; }
		public string TermId { get; }
		public string SessionId { get; }
		public string Title { get; set; }
		public LevelEnum Level { get; set; }
		internal AddLessonPlanCommand ToCommand(string instituteId, string fieldId, string courseId, string termId, string sessionId)
		{
			return new AddLessonPlanCommand()
			{
				InstituteId = instituteId,
				FieldId = fieldId,
				CourseId = courseId,
				TermId = termId,
				SessionId = sessionId,
				Title = Title,
				Level = Level
			};
		}

		internal UpdateLessonPlanCommand ToCommand(string instituteId, string fieldId, string courseId, string termId, string sessionId, string lessonplanId)
		{
			return new UpdateLessonPlanCommand()
			{
				InstituteId = instituteId,
				FieldId = fieldId,
				CourseId = courseId,
				TermId = termId,
				SessionId = sessionId,
				LessonplanId = lessonplanId,
				Title = Title,
				Level = Level
			};
		}
	}
}
