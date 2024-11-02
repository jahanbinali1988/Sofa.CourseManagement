using Sofa.CourseManagement.Application.Contract.Institutes.Dtos;
using Sofa.CourseManagement.SharedKernel.Application;

namespace Sofa.CourseManagement.Application.Contract.Institutes.Commands
{
    public class AddInstituteCommand : CommandBase<InstituteDto>
	{
		public string Title { get; set; }
		public string WebsiteUrl { get; set; }
		public string Code { get; set; }
        public bool IsActive { get; set; }
		public string Description { get; set; }
	}
}
