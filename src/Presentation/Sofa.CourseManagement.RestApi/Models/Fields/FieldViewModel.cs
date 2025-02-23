using Sofa.CourseManagement.Application.Contract.Fields.Dtos;

namespace Sofa.CourseManagement.RestApi.Models.Fields
{
	public class FieldViewModel : ViewModelBase
	{
		public string Title { get; set; }
		public string InstituteId { get; set; }
		public string InstituteTitle { get; set; }

		internal static FieldViewModel Create(FieldDto field)
		{
			return new FieldViewModel { Title = field.Title, Id = field.Id, InstituteId = field.InstituteId, InstituteTitle = field.InstituteTitle };
		}
	}
}
