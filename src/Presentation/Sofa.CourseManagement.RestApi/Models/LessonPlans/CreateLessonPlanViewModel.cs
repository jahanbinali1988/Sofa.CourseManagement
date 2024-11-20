using Sofa.CourseManagement.Application.Contract.LessonPlans.Commands;
using Sofa.CourseManagement.Domain.Institutes.Entities;
using Sofa.CourseManagement.Domain.Institutes;
using Sentry;
using Sofa.CourseManagement.Domain.Contract.Users.Enums;

namespace Sofa.CourseManagement.RestApi.Models.LessonPlans
{
    public class CreateLessonPlanViewModel : ViewModelBase
	{
		public Guid InstituteId { get; }
		public Guid FieldId { get; }
		public Guid CourseId { get; }
		public Guid TermId { get; }
		public Guid SessionId { get; }
		public string Title { get; set; }
		public LevelEnum Level { get; set; }
		internal AddLessonPlanCommand ToCommand(Guid instituteId, Guid fieldId, Guid courseId, Guid termId, Guid sessionId)
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

		internal UpdateLessonPlanCommand ToCommand(Guid instituteId, Guid fieldId, Guid courseId, Guid termId, Guid sessionId, Guid lessonplanId)
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
