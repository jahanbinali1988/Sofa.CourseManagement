using Sofa.CourseManagement.Application.Contract.Shared;
using Sofa.CourseManagement.Domain.Institutes;
using Sofa.CourseManagement.Domain.Institutes.ValueObjects;

namespace Sofa.CourseManagement.Application.Contract.Institutes.Dtos
{
	public class InstituteDto : EntityBaseDto
	{
		public string Title { get; set; }
		public string WebsiteUrl { get; set; }
		public Address Address { get; set; }
		public string Code { get; set; }

		public static InstituteDto CreateDto(Institute institute)
		{
			return new InstituteDto()
			{
				Title = institute.Title.Value,
				WebsiteUrl = institute.WebsiteUrl.Value,
				Address = institute.Address,
				Code = institute.Code.Value,
				Id = institute.Id
			};
		}
	}
}
