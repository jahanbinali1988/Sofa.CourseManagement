using Sofa.CourseManagement.Application.Contract.Fields.Commands;

namespace Sofa.CourseManagement.RestApi.Models.Fields
{
	public class CreateFieldViewModel : ViewModelBase
	{
		public string Title { get; set; }

		internal AddFieldCommand ToCommand(string instituteId)
		{
			return new AddFieldCommand()
			{
				Title = Title,
				InstituteId = instituteId
			};
		}

		internal UpdateFieldCommand ToCommand(string instituteId, string id)
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
