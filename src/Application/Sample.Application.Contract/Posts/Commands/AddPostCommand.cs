﻿using Sofa.CourseManagement.Application.Contract.Posts.Dtos;
using Sofa.CourseManagement.Domain.Contract.Institutes.Enums;
using Sofa.CourseManagement.SharedKernel.Application;
using System;

namespace Sofa.CourseManagement.Application.Contract.Posts.Commands
{
    public class AddPostCommand : CommandBase<PostBaseDto>
	{
		public ContentTypeEnum ContentType { get; set; }
		public dynamic Post { get; set; }
		public Guid LessonPlanId { get; set; }
		public Guid SessionId { get; set; }
		public Guid InstituteId { get; set; }
		public Guid FieldId { get; set; }
		public Guid CourseId { get; set; }
		public Guid TermId { get; set; }
	}
}
