using Sofa.CourseManagement.Application.Contract.Shared;
using Sofa.SharedKernel.Application;
using System;

namespace Sofa.CourseManagement.Application.Contract.Institutes.Commands
{
	public class UpdateInstituteCommand : CommandBase
	{
		public Id Id { get; set; }
		public string Title { get; set; }
		public string WebsiteUrl { get; set; }
		public string Code { get; set; }
	}
}
