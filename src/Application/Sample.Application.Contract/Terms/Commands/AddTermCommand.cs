using Sofa.CourseManagement.Application.Contract.Terms.Dtos;
using Sofa.CourseManagement.SharedKernel.Application;
using System;

namespace Sofa.CourseManagement.Application.Contract.Terms.Commands
{
    public class AddTermCommand : CommandBase<TermDto>
	{
		public string Title { get; set; }
		public Guid CourseId { get; set; }
		public Guid InstituteId { get; set; }
		public Guid FieldId { get; set; }
	}
}
