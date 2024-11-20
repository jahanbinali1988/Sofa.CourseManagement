using Sofa.CourseManagement.Domain.Contract.Users.Enums;
using Sofa.CourseManagement.SharedKernel.Application;
using System;

namespace Sofa.CourseManagement.Application.Contract.LessonPlans.Commands
{
    public class UpdateLessonPlanCommand : CommandBase
	{
        public Guid LessonplanId { get; set; }
		public string Title { get; set; }
		public LevelEnum Level { get; set; }
		public Guid SessionId { get; set; }
		public Guid InstituteId { get; set; }
		public Guid FieldId { get; set; }
		public Guid CourseId { get; set; }
		public Guid TermId { get; set; }
	}
}
