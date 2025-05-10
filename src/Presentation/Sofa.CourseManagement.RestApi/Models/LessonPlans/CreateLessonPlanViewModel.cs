using Sofa.CourseManagement.Application.Contract.LessonPlans.Commands;

namespace Sofa.CourseManagement.RestApi.Models.LessonPlans
{
    public class CreateLessonPlanViewModel : ViewModelBase
	{

		public string CourseLanguageId { get; set; }
		public string CourseLanguageTitle { get; set; }
		internal AddLessonPlanCommand ToCommand(string instituteId, string fieldId, string courseId, string sessionId)
		{
			return new AddLessonPlanCommand()
			{
				InstituteId = instituteId,
				FieldId = fieldId,
				CourseId = courseId,
				SessionId = sessionId,
				CourseLanguageTitle = this.CourseLanguageTitle,
				CourseLanguageId = this.CourseLanguageId
			};
		}

		internal UpdateLessonPlanCommand ToCommand(string instituteId, string fieldId, string courseId, string sessionId, string lessonplanId)
		{
			return new UpdateLessonPlanCommand()
			{
				InstituteId = instituteId,
				FieldId = fieldId,
				CourseId = courseId,
				SessionId = sessionId,
				LessonplanId = lessonplanId,
				Title = CourseLanguageTitle,
			};
		}
	}
}
