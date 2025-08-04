using Sofa.CourseManagement.Application.Contract.Shared;
using Sofa.CourseManagement.Domain.Contract.Users.Enums;
using Sofa.SharedKernel.Application;
using System;

namespace Sofa.CourseManagement.Application.Contract.LessonPlans.Commands
{
	public class UpdateLessonPlanCommand : CommandBase
	{
        public Id LessonplanId { get; set; }
		public string Title { get; set; }
		public Id SessionId { get; set; }
		public Id InstituteId { get; set; }
		public Id FieldId { get; set; }
		public Id CourseId { get; set; }
	}
}
