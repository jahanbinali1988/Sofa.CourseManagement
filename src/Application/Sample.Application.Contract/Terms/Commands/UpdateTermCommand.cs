using Sofa.CourseManagement.SharedKernel.Application;
using System;

namespace Sofa.CourseManagement.Application.Contract.Terms.Commands
{
    public class UpdateTermCommand : CommandBase
	{
        public Guid Id { get; set; }
        public string Title { get; set; }
		public Guid CourseId { get; set; }
		public Guid InstituteId { get; set; }
		public Guid FieldId { get; set; }
	}
}
