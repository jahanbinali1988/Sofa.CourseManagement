using Microsoft.AspNetCore.Mvc;
using Sofa.CourseManagement.RestApi.Models.Courses;
using Sofa.CourseManagement.RestApi.Models;
using Sofa.CourseManagement.SharedKernel.Application;
using Sofa.CourseManagement.Application.Contract.CoursePlacements.Queries;
using Sofa.CourseManagement.Application.Contract.CoursePlacements.Commands;

namespace Sofa.CourseManagement.RestApi.Controllers
{
	public partial class InstituteController
	{
		/// <summary>
		/// Create Course Placement entity
		/// </summary>
		/// <param name="request"></param>
		/// <response code="201" >Entity created</response>
		/// <response code="400">Entity has missing/invalid values</response>
		[HttpPost("/institute/{instituteId:required}/field/{fieldId:required}/course/{courseId:required}/placement")]
		public async Task<ActionResult<CoursePlacementViewModel>> CreateCoursePlacementAsync([FromRoute] string instituteId, [FromRoute] string fieldId, [FromRoute] string courseId, [FromBody] CreateCoursePlacementViewModel request)
		{
			var command = request.ToCommand(instituteId, fieldId, courseId);

			var coursePlacemntDto = await _mediator.Send(command);

			return CoursePlacementViewModel.Create(coursePlacemntDto);
		}

		/// <summary>
		/// Get Course Placement by Id
		/// </summary>
		/// <param name="id"></param>
		/// <response code="200">Successfully get entity</response>
		/// <response code="400">Entity has missing/invalid values</response>
		/// <response code="404">Entity not found</response>
		[HttpGet("/institute/{instituteId:required}/field/{fieldId:required}/course/{courseId:required}/placement/{placementId:required}")]
		public async Task<ActionResult<CoursePlacementViewModel>> GetCoursePlacementByIdAsync([FromRoute] string instituteId, [FromRoute] string fieldId,
			[FromRoute] string courseId, [FromRoute] string placementId)
		{
			var query = new GetCoursePlacementByIdQuery(instituteId, fieldId, courseId, placementId);

			var coursePlacement = await _mediator.Send(query, HttpContext.RequestAborted);

			return CoursePlacementViewModel.Create(coursePlacement);
		}

		/// <summary>
		/// Get Course Placements list
		/// </summary>
		/// <param name="request"></param>
		/// <response code="200">Successfully get entities</response>
		/// <response code="400">Entity has missing/invalid values</response>
		/// <response code="404">Entity not found</response>
		[HttpGet("/institute/{instituteId:required}/field/{fieldId:required}/course/{courseId:required}/placement")]
		public async Task<ActionResult<Pagination<CoursePlacementViewModel>>> GetCoursePlacementListAsync([FromRoute] string instituteId, [FromRoute] string fieldId, [FromRoute] string courseId, [FromQuery] GetListRequest request)
		{
			var query = new GetAllCoursePlacementsQuery(instituteId, fieldId, courseId, request.Offset, request.Count, request.Keyword);

			var coursePlacements = await _mediator.Send(query, HttpContext.RequestAborted);

			return coursePlacements.Map();
		}

		/// <summary>
		/// Update Course Placement entity
		/// </summary>
		/// <param name="id"></param>
		/// <param name="request"></param>
		/// <response code="201" >Entity created</response>
		/// <response code="400">Entity has missing/invalid values</response>
		[HttpPut("/institute/{instituteId:required}/field/{fieldId:required}/course/{courseId:required}/placement/{placementId:required}")]
		public async Task<ActionResult> UpdateCoursePlacementAsync([FromRoute] string instituteId, [FromRoute] string fieldId, [FromRoute] string courseId, [FromRoute] string placementId, [FromBody] CreateCoursePlacementViewModel request)
		{
			var command = request.ToCommand(instituteId, fieldId, courseId, placementId);

			await _mediator.Send(command);

			return Ok();
		}

		/// <summary>
		/// Delete Course Placement entity
		/// </summary>
		/// <param name="id"></param>
		/// <response code="201" >Entity created</response>
		/// <response code="400">Entity has missing/invalid values</response>
		[HttpDelete("/institute/{instituteId:required}/field/{fieldId:required}/course/{courseId:required}/placement/{placementId:required}")]
		public async Task<ActionResult> DeleteCoursePlacementAsync([FromRoute] string instituteId, [FromRoute] string fieldId, [FromRoute] string courseId, [FromRoute] string placementId)
		{
			var command = new DeleteCoursePlacementCommand(instituteId, fieldId, courseId, placementId);

			await _mediator.Send(command);

			return NoContent();
		}
	}
}
