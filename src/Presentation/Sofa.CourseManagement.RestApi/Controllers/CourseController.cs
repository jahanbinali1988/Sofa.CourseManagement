using Microsoft.AspNetCore.Mvc;
using Sofa.CourseManagement.RestApi.Models;
using Sofa.CourseManagement.RestApi.Models.Courses;
using Sofa.CourseManagement.Application.Contract.Courses.Commands;
using Sofa.CourseManagement.Application.Contract.Courses.Dtos;
using Sofa.CourseManagement.Application.Contract.Courses.Queries;
using Sofa.CourseManagement.Domain.Institutes.Entities;

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
		public async Task<ActionResult<CourseViewModel>> CreateCourseAsync([FromQuery] Guid instituteId, [FromQuery] Guid fieldId, [FromBody] CreateCourseViewModel request)
		{
			var command = request.ToCommand(instituteId, fieldId);

			var course = await _mediator.Send(command);

			return Created(CourseViewModel.Create(course));
		}

		/// <summary>
		/// Get Course by Id
		/// </summary>
		/// <param name="id"></param>
		/// <response code="200">Successfully get entity</response>
		/// <response code="400">Entity has missing/invalid values</response>
		/// <response code="404">Entity not found</response>
		[HttpGet("/institute/{instituteId:required}/field/{fieldId:required}/course/{courseId:required}")]
		public async Task<ActionResult<CourseViewModel>> GetCourseByIdAsync([FromQuery] Guid instituteId, [FromQuery] Guid fieldId, [FromQuery] Guid courseId)
		{
			var query = new GetCourseByIdQuery(instituteId, fieldId, courseId);

			var course = await _mediator.Send(query, HttpContext.RequestAborted);

			return Get<CourseViewModel>(CourseViewModel.Create(course));
		}

		/// <summary>
		/// Get Courses list
		/// </summary>
		/// <param name="request"></param>
		/// <response code="200">Successfully get entities</response>
		/// <response code="400">Entity has missing/invalid values</response>
		/// <response code="404">Entity not found</response>
		[HttpGet("/institute/{instituteId:required}/field/{fieldId:required}/course")]
		public async Task<ActionResult<IEnumerable<CourseViewModel>>> GetCourseListAsync([FromQuery] Guid instituteId, [FromQuery] Guid fieldId, [FromQuery] GetListRequest request)
		{
			var query = new GetAllCoursesQuery(instituteId, fieldId, request.Offset, request.Count, request.Keyword);

			var courses = await _mediator.Send(query, HttpContext.RequestAborted);

			return List<CourseDto, CourseViewModel>(courses);
		}

		/// <summary>
		/// Create Course entity
		/// </summary>
		/// <param name="id"></param>
		/// <param name="request"></param>
		/// <response code="201" >Entity created</response>
		/// <response code="400">Entity has missing/invalid values</response>
		[HttpPut("/institute/{instituteId:required}/field/{fieldId:required}/course/{courseId:required}")]
		public async Task<ActionResult> UpdateCourseAsync([FromQuery] Guid instituteId, [FromQuery] Guid fieldId, [FromQuery] Guid courseId, [FromBody] CreateCourseViewModel request)
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
		[HttpDelete("/institute/{instituteId:required}/field/{fieldId:required}/course/{id:required}")]
		public async Task<ActionResult> DeleteCourseAsync([FromQuery] Guid instituteId, [FromQuery] Guid fieldId, [FromQuery] Guid courseId)
		{
			var command = new DeleteCourseCommand(instituteId, fieldId, courseId);

			await _mediator.Send(command);

			return NoContent();
		}
	}
}
