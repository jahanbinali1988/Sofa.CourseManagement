using Sofa.CourseManagement.Application.Contract.Shared;
using Sofa.CourseManagement.SharedKernel.Application;

namespace Sofa.CourseManagement.Application.Contract.Institutes.Commands
{
	public class DeleteInstituteCommand : CommandBase
	{
		public DeleteInstituteCommand(string id)
		{
			this.Id = id;
		}
        public Id Id { get; set; }
    }
}
