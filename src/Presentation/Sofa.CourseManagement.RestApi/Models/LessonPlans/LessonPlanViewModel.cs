using Sofa.CourseManagement.Application.Contract.LessonPlans.Dtos;

namespace Sofa.CourseManagement.RestApi.Models.LessonPlans
{
    public class LessonPlanViewModel : ViewModelBase
	{
        public string Title { get; set; }
		public string SessionId { get; set; }

		internal static LessonPlanViewModel Create(LessonPlanDto lessonPlan)
		{
			return new LessonPlanViewModel 
			{ 
				Id = lessonPlan.Id, 
				SessionId = lessonPlan.SessionId,
				Title = lessonPlan.Title,
			};
		}
	}
}
