using Sofa.CourseManagement.Application.Contract.Terms.Commands;

namespace Sofa.CourseManagement.RestApi.Models.Terms
{
	public class CreateTermViewModel : ViewModelBase
	{
		public string Title { get; set; }

		internal AddTermCommand ToCommand(Guid instituteId, Guid fieldId, Guid courseId)
		{
			return new AddTermCommand 
			{
				Title = Title,
				InstituteId = instituteId,
				FieldId = fieldId,
				CourseId = courseId
			};
		}

		internal UpdateTermCommand ToCommand(Guid instituteId, Guid fieldId, Guid courseId, Guid id)
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
