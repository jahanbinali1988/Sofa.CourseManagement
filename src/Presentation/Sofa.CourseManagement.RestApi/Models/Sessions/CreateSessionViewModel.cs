using Sofa.CourseManagement.Application.Contract.Sessions.Commands;

namespace Sofa.CourseManagement.RestApi.Models.Sessions
{
	public class CreateSessionViewModel : ViewModelBase
	{
		public string Title { get; set; }

		internal AddSessionCommand ToCommand(Guid instituteId, Guid fieldId, Guid courseId, Guid termId)
		{
			return new AddSessionCommand()
			{
				Title = Title,
				InstituteId = instituteId,
				FieldId = fieldId,
				CourseId = courseId,
				TermId = termId
			};
		}

		internal UpdateSessionCommand ToCommand(Guid instituteId, Guid fieldId, Guid courseId, Guid termId, Guid id)
		{
			return new UpdateSessionCommand()
			{
				Title = Title,
				InstituteId = instituteId,
				FieldId = fieldId,
				CourseId = courseId,
				TermId = termId,
				Id = id
			};
		}
	}
}
