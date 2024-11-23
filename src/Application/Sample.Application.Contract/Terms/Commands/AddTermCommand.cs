using Sofa.CourseManagement.Application.Contract.Terms.Dtos;
using Sofa.CourseManagement.SharedKernel.Application;
using System;

namespace Sofa.CourseManagement.Application.Contract.Terms.Commands
{
    public class AddTermCommand : CommandBase<TermDto>
	{
		public string Title { get; set; }
		public Id CourseId { get; set; }
		public Id InstituteId { get; set; }
		public Id FieldId { get; set; }
	}
}
