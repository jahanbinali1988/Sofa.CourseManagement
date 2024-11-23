using Sofa.CourseManagement.Application.Contract.Sessions.Commands;

namespace Sofa.CourseManagement.RestApi.Models.Sessions
{
	public class CreateSessionViewModel : ViewModelBase
	{
		public string Title { get; set; }
		public DateTimeOffset OccurredDate { get; set; }

		internal AddSessionCommand ToCommand(string instituteId, string fieldId, string courseId, string termId)
		{
			return new AddSessionCommand()
			{
				Title = Title,
				InstituteId = instituteId,
				FieldId = fieldId,
				CourseId = courseId,
				TermId = termId,
				OccurredDate = OccurredDate
			};
		}

		internal UpdateSessionCommand ToCommand(string instituteId, string fieldId, string courseId, string termId, string id)
		{
			return new UpdateSessionCommand()
			{
				Title = Title,
				InstituteId = instituteId,
				FieldId = fieldId,
				CourseId = courseId,
				TermId = termId,
				Id = id,
				OccurredDate = OccurredDate
			};
		}
	}
}
