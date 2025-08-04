using Sofa.CourseManagement.Application.Contract.Shared;
using Sofa.SharedKernel.Application;
using System;

namespace Sofa.CourseManagement.Application.Contract.Fields.Commands
{
	public class DeleteFieldCommand : CommandBase
    {
        public Id Id { get; set; }
		public Id InstituteId { get; set; }

		public DeleteFieldCommand(string instituteId, string id)
		{
			Id = id;
			InstituteId = instituteId;
		}
	}
}
