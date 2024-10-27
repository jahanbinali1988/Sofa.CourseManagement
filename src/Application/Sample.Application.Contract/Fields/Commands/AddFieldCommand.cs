using Sofa.CourseManagement.Application.Contract.Fields.Dtos;
using Sofa.CourseManagement.SharedKernel.Application;
using System;

namespace Sofa.CourseManagement.Application.Contract.Fields.Commands
{
    public class AddFieldCommand : CommandBase<FieldDto>
	{
		public string Title { get; set; }
		public Guid InstituteId { get; set; }
	}
}
