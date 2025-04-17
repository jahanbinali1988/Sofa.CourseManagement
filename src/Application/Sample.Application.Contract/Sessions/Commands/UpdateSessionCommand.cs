using Sofa.CourseManagement.Application.Contract.Shared;
using Sofa.CourseManagement.SharedKernel.Application;
using System;

namespace Sofa.CourseManagement.Application.Contract.Sessions.Commands
{
	public class UpdateSessionCommand : CommandBase
	{
        public Id Id { get; set; }
        public string Title { get; set; }
		public Id InstituteId { get; set; }
		public Id FieldId { get; set; }
		public Id CourseId { get; set; }
		public DateTimeOffset OccurredDate { get; set; }
	}
}
