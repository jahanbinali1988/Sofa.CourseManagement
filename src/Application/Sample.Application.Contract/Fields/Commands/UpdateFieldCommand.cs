using Sofa.CourseManagement.SharedKernel.Application;
using System;

namespace Sofa.CourseManagement.Application.Contract.Fields.Commands
{
    public class UpdateFieldCommand : CommandBase
	{
        public Guid Id { get; set; }
        public string Title { get; set; }
		public Guid InstituteId { get; set; }
	}
}
