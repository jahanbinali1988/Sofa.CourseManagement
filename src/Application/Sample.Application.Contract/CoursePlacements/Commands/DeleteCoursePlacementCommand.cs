using Sofa.CourseManagement.Application.Contract.Shared;
using Sofa.SharedKernel.Application;

namespace Sofa.CourseManagement.Application.Contract.CoursePlacements.Commands
{
	public class DeleteCoursePlacementCommand : CommandBase
	{
		public DeleteCoursePlacementCommand(string instituteId, string fieldId, string courseId, string id) 
		{
			Id = id;
			CourseId = courseId;
			FieldId = fieldId;
			InstituteId = instituteId;
		}
		public Id Id { get; set; }
		public Id CourseId { get; set; }
		public Id FieldId { get; set; }
		public Id InstituteId { get; set; }
	}
}
