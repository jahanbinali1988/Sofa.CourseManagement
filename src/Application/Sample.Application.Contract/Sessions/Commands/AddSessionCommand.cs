using Sofa.CourseManagement.Application.Contract.Sessions.Dtos;
using Sofa.CourseManagement.SharedKernel.Application;
using System;

namespace Sofa.CourseManagement.Application.Contract.Sessions.Commands
{
    public class AddSessionCommand : CommandBase<SessionDto>
	{
		public string Title { get; set; }
		public Guid InstituteId { get; set; }
		public Guid FieldId { get; set; }
		public Guid CourseId { get; set; }
		public Guid TermId { get; set; }
		public DateTimeOffset OccurredDate { get; set; }
	}
}
