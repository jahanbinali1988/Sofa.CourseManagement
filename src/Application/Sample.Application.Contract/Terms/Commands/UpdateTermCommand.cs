using Sofa.CourseManagement.SharedKernel.Application;
using System;

namespace Sofa.CourseManagement.Application.Contract.Terms.Commands
{
    public class UpdateTermCommand : CommandBase
	{
        public Id Id { get; set; }
        public string Title { get; set; }
		public Id CourseId { get; set; }
		public Id InstituteId { get; set; }
		public Id FieldId { get; set; }
	}
}
