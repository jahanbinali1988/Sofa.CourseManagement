using Sofa.CourseManagement.Application.Contract.Fields.Commands;

namespace Sofa.CourseManagement.RestApi.Models.Fields
{
	public class CreateFieldViewModel : ViewModelBase
	{
		public string Title { get; set; }

		internal AddFieldCommand ToCommand(Guid instituteId)
		{
			return new AddFieldCommand()
			{
				Title = Title,
				InstituteId = instituteId
			};
		}

		internal UpdateFieldCommand ToCommand(Guid instituteId, Guid id)
		{
			return new UpdateFieldCommand()
			{
				Title = Title,
				InstituteId = instituteId,
				Id = id
			};
		}
	}
}
