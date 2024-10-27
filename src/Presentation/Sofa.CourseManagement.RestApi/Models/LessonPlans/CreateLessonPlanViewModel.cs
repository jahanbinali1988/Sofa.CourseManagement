using Sofa.CourseManagement.Application.Contract.LessonPlans.Commands;
using Sofa.CourseManagement.Domain.Contract.Institutes.Enums;

namespace Sofa.CourseManagement.RestApi.Models.LessonPlans
{
    public class CreateLessonPlanViewModel : ViewModelBase
	{
		public string Title { get; set; }
		public LevelEnum Level { get; set; }
		public Guid SessionId { get; set; }

		internal AddLessonPlanCommand ToCommand()
		{
			return new AddLessonPlanCommand() 
			{
				Title = Title,
				Level = Level,
				SessionId = SessionId
			};
		}

		internal UpdateLessonPlanCommand ToCommand(Guid id)
		{
			return new UpdateLessonPlanCommand()
			{
				Id = id,
				Title = Title,
				SessionId = SessionId,
				Level = Level
			};
		}
	}
}
