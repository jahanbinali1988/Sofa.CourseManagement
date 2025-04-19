using Microsoft.AspNetCore.Mvc;
using Sofa.CourseManagement.RestApi.Models.Courses;
using Sofa.CourseManagement.RestApi.Models;
using Sofa.CourseManagement.SharedKernel.Application;
using Sofa.CourseManagement.Application.Contract.CoursePlacementQuestions.Commands;
using Sofa.CourseManagement.Application.Contract.CoursePlacementQuestions.Queries;

namespace Sofa.CourseManagement.RestApi.Controllers
{
	public partial class InstituteController
	{
		/// <summary>
		/// Create Course Placement Question entity
		/// </summary>
		/// <param name="request"></param>
		/// <response code="201" >Entity created</response>
		/// <response code="400">Entity has missing/invalid values</response>
		[HttpPost("/institute/{instituteId:required}/field/{fieldId:required}/course/{courseId:required}/placement/{placementId:required}/question")]
		public async Task<ActionResult<CoursePlacementQuestionViewModel>> CreateCoursePlacementQuestionAsync([FromRoute] string instituteId, [FromRoute] string fieldId, [FromRoute] string courseId, [FromRoute] string placementId, [FromBody] CreateCoursePlacementQuestionViewModel request)
		{
			var command = request.ToCommand(instituteId, fieldId, courseId, placementId);

			var course = await _mediator.Send(command);

			return CoursePlacementQuestionViewModel.Create(course);
		}
		/// <summary>
		/// Get Course Placement Questions list
		/// </summary>
		/// <param name="request"></param>
		/// <response code="200">Successfully get entities</response>
		/// <response code="400">Entity has missing/invalid values</response>
		/// <response code="404">Entity not found</response>
		[HttpGet("/institute/{instituteId:required}/field/{fieldId:required}/course/{courseId:required}/placement/{placementId:required}/question")]
		public async Task<ActionResult<Pagination<CoursePlacementQuestionViewModel>>> GetCourseUserListAsync([FromRoute] string instituteId, [FromRoute] string fieldId, [FromRoute] string courseId, [FromRoute] string placementId, [FromQuery] GetListRequest request)
		{
			var query = new GetAllCoursePlacementQuestionsQuery(instituteId, fieldId, courseId, placementId, request.Offset, request.Count, request.Keyword);

			var coursePlacementQuestions = await _mediator.Send(query, HttpContext.RequestAborted);

			return coursePlacementQuestions.Map();
		}
		/// <summary>
		/// Delete Course Placement Question entity
		/// </summary>
		/// <param name="id"></param>
		/// <response code="201" >Entity created</response>
		/// <response code="400">Entity has missing/invalid values</response>
		[HttpDelete("/institute/{instituteId:required}/field/{fieldId:required}/course/{courseId:required}/placement/{placementId:required}/question/{questionId:required}")]
		public async Task<ActionResult> DeleteCoursePlacementQuestionAsync([FromRoute] string instituteId, [FromRoute] string fieldId, [FromRoute] string courseId, [FromRoute] string placementId, [FromRoute] string questionId)
		{
			var command = new DeleteCoursePlacementQuestionCommand(instituteId, fieldId, courseId, placementId, questionId);

			await _mediator.Send(command);

			return NoContent();
		}
	}
}
