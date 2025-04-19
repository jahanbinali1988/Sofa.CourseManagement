using Microsoft.AspNetCore.Mvc;
using Sofa.CourseManagement.Application.Contract.Courses.Commands;
using Sofa.CourseManagement.RestApi.Models.Courses;
using Sofa.CourseManagement.RestApi.Models;
using Sofa.CourseManagement.SharedKernel.Application;
using Sofa.CourseManagement.Application.Contract.CourseUsers.Queries;

namespace Sofa.CourseManagement.RestApi.Controllers
{
	public partial class InstituteController
	{
		/// <summary>
		/// Create Course User entity
		/// </summary>
		/// <param name="request"></param>
		/// <response code="201" >Entity created</response>
		/// <response code="400">Entity has missing/invalid values</response>
		[HttpPost("/institute/{instituteId:required}/field/{fieldId:required}/course/{courseId:required}/user")]
		public async Task<ActionResult<CourseUserViewModel>> CreateCourseUserAsync([FromRoute] string instituteId, [FromRoute] string fieldId, 
			[FromRoute] string courseId, [FromBody] CreateCourseUserViewModel request)
		{
			var command = request.ToCommand(instituteId, fieldId, courseId);

			var courseUser = await _mediator.Send(command);

			return CourseUserViewModel.Create(courseUser);
		}
		/// <summary>
		/// Get Course Users list
		/// </summary>
		/// <param name="request"></param>
		/// <response code="200">Successfully get entities</response>
		/// <response code="400">Entity has missing/invalid values</response>
		/// <response code="404">Entity not found</response>
		[HttpGet("/institute/{instituteId:required}/field/{fieldId:required}/course/{courseId:required}/user")]
		public async Task<ActionResult<Pagination<CourseUserViewModel>>> GetCourseUserListAsync([FromRoute] string instituteId, [FromRoute] string fieldId,
			[FromRoute] string courseId, [FromQuery] GetListRequest request)
		{
			var query = new GetAllCourseUsersQuery(request.Offset, request.Count, request.Keyword, instituteId, fieldId, courseId);

			var courseUsers = await _mediator.Send(query, HttpContext.RequestAborted);

			return courseUsers.Map();
		}
		/// <summary>
		/// Delete Course User entity
		/// </summary>
		/// <param name="id"></param>
		/// <response code="201" >Entity created</response>
		/// <response code="400">Entity has missing/invalid values</response>
		[HttpDelete("/institute/{instituteId:required}/field/{fieldId:required}/course/{courseId:required}/user/{courseUserId:required}")]
		public async Task<ActionResult> DeleteCourseUserAsync([FromRoute] string instituteId, [FromRoute] string fieldId, [FromRoute] string courseId, [FromRoute] string courseUserId)
		{
			var command = new DeleteCourseCommand(instituteId, fieldId, courseId);

			await _mediator.Send(command);

			return NoContent();
		}
	}
}
