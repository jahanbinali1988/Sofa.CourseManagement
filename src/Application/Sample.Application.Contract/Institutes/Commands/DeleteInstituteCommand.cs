using Sofa.CourseManagement.SharedKernel.Application;
using System;

namespace Sofa.CourseManagement.Application.Contract.Institutes.Commands
{
	public class DeleteInstituteCommand : CommandBase
	{
		public DeleteInstituteCommand(Guid id)
		{
			this.Id = id;
		}
        public Guid Id { get; set; }
    }
}
