using Sofa.CourseManagement.Application.Contract.LessonPlans.Dtos;
using Sofa.CourseManagement.Domain.Contract.Institutes.Enums;

namespace Sofa.CourseManagement.RestApi.Models.LessonPlans
{
    public class LessonPlanViewModel : ViewModelBase
	{
        public string Title { get; set; }
        public LevelEnum Level { get; set; }
		public Guid SessionId { get; set; }

		internal static LessonPlanViewModel Create(LessonPlanDto lessonPlan)
		{
			return new LessonPlanViewModel 
			{ 
				Level = lessonPlan.Level, 
				Id = lessonPlan.Id, 
				SessionId = lessonPlan.SessionId,
				Title = lessonPlan.Title,
			};
		}
	}
}
