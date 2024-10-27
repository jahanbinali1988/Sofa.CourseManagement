using Sofa.CourseManagement.Application.Contract.Institutes.Dtos;
using Sofa.CourseManagement.Domain.Institutes.ValueObjects;

namespace Sofa.CourseManagement.RestApi.Models.Institutes
{
	public class InstituteViewModel : ViewModelBase
	{
		public Guid Id { get; set; }
		public string Title { get; set; }
		public string WebsiteUrl { get; set; }
		public Address Address { get; set; }
		public string Code { get; set; }
		public static InstituteViewModel Create(InstituteDto institute)
		{
			return new InstituteViewModel()
			{
				Id = institute.Id,
				Address = institute.Address,
				Title = institute.Title,
				Code = institute.Code,
				WebsiteUrl = institute.WebsiteUrl
			};
		}
	}
}
