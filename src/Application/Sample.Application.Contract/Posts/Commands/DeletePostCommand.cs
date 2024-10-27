using Sofa.CourseManagement.SharedKernel.Application;
using System;

namespace Sofa.CourseManagement.Application.Contract.Posts.Commands
{
    public class DeletePostCommand : CommandBase
    {
		public Guid LessonpalnId { get; }
		public Guid Id { get; set; }

		public DeletePostCommand(Guid lessonpalnId, Guid id)
		{
			LessonpalnId = lessonpalnId;
			Id = id;
		}
	}
}
