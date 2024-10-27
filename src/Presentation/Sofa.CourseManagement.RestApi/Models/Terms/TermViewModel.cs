using Sofa.CourseManagement.Application.Contract.Terms.Dtos;

namespace Sofa.CourseManagement.RestApi.Models.Terms
{
	public class TermViewModel : ViewModelBase
	{
		public string Title { get; set; }
		public Guid CourseId { get; set; }

		internal static TermViewModel Create(TermDto term)
		{
			return new TermViewModel { Title = term.Title, CourseId = term.CourseId, Id = term.Id };
		}
	}
}
