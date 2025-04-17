using Sofa.CourseManagement.Application.Contract.Shared;
using Sofa.CourseManagement.SharedKernel.Application;

namespace Sofa.CourseManagement.Application.Contract.Fields.Commands
{
	public class UpdateFieldCommand : CommandBase
	{
        public Id Id { get; set; }
        public string Title { get; set; }
		public Id InstituteId { get; set; }
	}
}
