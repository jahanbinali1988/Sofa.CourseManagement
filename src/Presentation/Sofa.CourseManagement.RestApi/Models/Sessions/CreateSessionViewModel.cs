using Sofa.CourseManagement.Application.Contract.Sessions.Commands;

namespace Sofa.CourseManagement.RestApi.Models.Sessions
{
	public class CreateSessionViewModel : ViewModelBase
	{
		public string Title { get; set; }
		public DateTimeOffset OccurredDate { get; set; }

		internal AddSessionCommand ToCommand(string instituteId, string fieldId, string courseId)
		{
			return new AddSessionCommand()
			{
				Title = Title,
				InstituteId = instituteId,
				FieldId = fieldId,
				CourseId = courseId,
				OccurredDate = OccurredDate
			};
		}

		internal UpdateSessionCommand ToCommand(string instituteId, string fieldId, string courseId, string id)
		{
			return new UpdateSessionCommand()
			{
				Title = Title,
				InstituteId = instituteId,
				FieldId = fieldId,
				CourseId = courseId,
				Id = id,
				OccurredDate = OccurredDate
			};
		}
	}
}
