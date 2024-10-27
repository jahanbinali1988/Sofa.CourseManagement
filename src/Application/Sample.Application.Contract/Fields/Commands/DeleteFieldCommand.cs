using Sofa.CourseManagement.SharedKernel.Application;
using System;

namespace Sofa.CourseManagement.Application.Contract.Fields.Commands
{
    public class DeleteFieldCommand : CommandBase
    {
        public Guid Id { get; set; }
		public Guid InstituteId { get; set; }

		public DeleteFieldCommand(Guid instituteId, Guid id)
		{
			Id = id;
			InstituteId = instituteId;
		}
	}
}
