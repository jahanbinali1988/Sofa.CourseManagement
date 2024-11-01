﻿using Sofa.CourseManagement.Application.Contract.LessonPlans.Dtos;
using Sofa.CourseManagement.Domain.Contract.Institutes.Enums;
using Sofa.CourseManagement.SharedKernel.Application;
using System;

namespace Sofa.CourseManagement.Application.Contract.LessonPlans.Commands
{
    public class AddLessonPlanCommand : CommandBase<LessonPlanDto>
	{
		public string Title { get; set; }
		public LevelEnum Level { get; set; }
		public Guid SessionId { get; set; }
	}
}
