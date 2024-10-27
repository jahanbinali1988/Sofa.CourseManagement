using Sofa.CourseManagement.Domain.Institutes.ValueObjects;
using Sofa.CourseManagement.SharedKernel.Application;
using System;

namespace Sofa.CourseManagement.Application.Contract.Institutes.Commands
{
    public class UpdateInstituteCommand : CommandBase
	{
		public Guid Id { get; set; }
		public string Title { get; set; }
		public string WebsiteUrl { get; set; }
		public string Code { get; set; }
	}
}
