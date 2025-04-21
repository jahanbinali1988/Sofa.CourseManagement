using Microsoft.AspNetCore.Mvc;
using Sofa.CourseManagement.RestApi.Models;
using Sofa.CourseManagement.RestApi.Models.Courses;
using Sofa.CourseManagement.Application.Contract.Courses.Commands;
using Sofa.CourseManagement.Application.Contract.Courses.Queries;
using Sofa.CourseManagement.SharedKernel.Application;

namespace Sofa.CourseManagement.RestApi.Controllers
{
	public partial class InstituteController
	{
		/// <summary>
		/// Create Course entity
		/// </summary>
		/// <param name="request"></param>
		/// <response code="201" >Entity created</response>
		/// <response code="400">Entity has missing/invalid values</response>
		[HttpPost("/institute/{instituteId:required}/field/{fieldId:required}/course")]
		public async Task<ActionResult<CourseViewModel>> CreateCourseAsync([FromRoute] string instituteId, [FromRoute] string fieldId, [FromBody] CreateCourseViewModel request)
		{
			var command = request.ToCommand(instituteId, fieldId);

			var course = await _mediator.Send(command);

			return CourseViewModel.Create(course);
		}

		/// <summary>
		/// Get Course by Id
		/// </summary>
		/// <param name="id"></param>
		/// <response code="200">Successfully get entity</response>
		/// <response code="400">Entity has missing/invalid values</response>
		/// <response code="404">Entity not found</response>
		[HttpGet("/institute/{instituteId:required}/field/{fieldId:required}/course/{courseId:required}")]
		public async Task<ActionResult<CourseViewModel>> GetCourseByIdAsync([FromRoute] string instituteId, [FromRoute] string fieldId, 
			[FromRoute] string courseId)
		{
			var query = new GetCourseByIdQuery(instituteId, fieldId, courseId);

			var course = await _mediator.Send(query, HttpContext.RequestAborted);

			return CourseViewModel.Create(course);
		}

		/// <summary>
		/// Get Courses list
		/// </summary>
		/// <param name="request"></param>
		/// <response code="200">Successfully get entities</response>
		/// <response code="400">Entity has missing/invalid values</response>
		/// <response code="404">Entity not found</response>
		[HttpGet("/institute/{instituteId:required}/field/{fieldId:required}/course")]
		public async Task<ActionResult<Pagination<CourseViewModel>>> GetCourseListAsync([FromRoute] string instituteId, [FromRoute] string fieldId, [FromQuery] GetListRequest request)
		{
			var query = new GetAllCoursesQuery(instituteId, fieldId, request.Offset, request.Count, request.Keyword);

			var courses = await _mediator.Send(query, HttpContext.RequestAborted);

			return courses.Map();
		}

		/// <summary>
		/// Create Course entity
		/// </summary>
		/// <param name="id"></param>
		/// <param name="request"></param>
		/// <response code="201" >Entity created</response>
		/// <response code="400">Entity has missing/invalid values</response>
		[HttpPut("/institute/{instituteId:required}/field/{fieldId:required}/course/{courseId:required}")]
		public async Task<ActionResult> UpdateCourseAsync([FromRoute] string instituteId, [FromRoute] string fieldId, [FromRoute] string courseId, [FromBody] CreateCourseViewModel request)
		{
			var command = request.ToCommand(instituteId, fieldId, courseId);

			await _mediator.Send(command);

			return Ok();
		}

		/// <summary>
		/// Create Course entity
		/// </summary>
		/// <param name="id"></param>
		/// <response code="201" >Entity created</response>
		/// <response code="400">Entity has missing/invalid values</response>
		[HttpDelete("/institute/{instituteId:required}/field/{fieldId:required}/course/{courseId:required}")]
		public async Task<ActionResult> DeleteCourseAsync([FromRoute] string instituteId, [FromRoute] string fieldId, [FromRoute] string courseId)
		{
			var command = new DeleteCourseCommand(instituteId, fieldId, courseId);

			await _mediator.Send(command);

			return NoContent();
		}
	}
}
