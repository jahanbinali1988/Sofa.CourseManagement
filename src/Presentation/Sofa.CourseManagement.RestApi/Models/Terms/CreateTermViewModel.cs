using Sofa.CourseManagement.Application.Contract.Terms.Commands;

namespace Sofa.CourseManagement.RestApi.Models.Terms
{
	public class CreateTermViewModel : ViewModelBase
	{
		public string Title { get; set; }

		internal AddTermCommand ToCommand(string instituteId, string fieldId, string courseId)
		{
			return new AddTermCommand 
			{
				Title = Title,
				InstituteId = instituteId,
				FieldId = fieldId,
				CourseId = courseId
			};
		}

		internal UpdateTermCommand ToCommand(string instituteId, string fieldId, string courseId, string id)
		{
			return new UpdateTermCommand()
			{
				Id = id,
				Title = Title,
				InstituteId = instituteId,
				FieldId = fieldId,
				CourseId = courseId
			};
		}
	}
}
