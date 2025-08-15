using Sofa.CourseManagement.Application.Contract.Sessions.Commands;
using Sofa.CourseManagement.Domain.Institutes.ValueObjects;

namespace Sofa.CourseManagement.RestApi.Models.Sessions
{
	public class CreateSessionViewModel : ViewModelBase
	{
		public string Title { get; set; }
		public byte Priority { get; set; }

		internal AddSessionCommand ToCommand(string instituteId, string fieldId, string courseId)
		{
			return new AddSessionCommand()
			{
				Title = Title,
				InstituteId = instituteId,
				FieldId = fieldId,
				CourseId = courseId,
				Priority = Priority
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
				Priority = Priority
			};
		}
	}
}
