using Microsoft.AspNetCore.Mvc;
using Sofa.CourseManagement.Application.Contract.CourseLanguages.Commands;
using Sofa.CourseManagement.Application.Contract.CourseLanguages.Queries;
using Sofa.CourseManagement.RestApi.Models;
using Sofa.CourseManagement.RestApi.Models.Courses;
using Sofa.SharedKernel.Application;

namespace Sofa.CourseManagement.RestApi.Controllers
{
	public partial class InstituteController
	{
		/// <summary>
		/// Create Course Language entitys
		/// </summary>
		/// <param name="request"></param>
		/// <response code="201" >Entity created</response>
		/// <response code="400">Entity has missing/invalid values</response>
		[HttpPost("/institute/{instituteId:required}/field/{fieldId:required}/course/{courseId:required}/language")]
		public async Task<ActionResult<CourseLanguageViewModel>> CreateCourseLanguageAsync([FromRoute] string instituteId, [FromRoute] string fieldId, [FromRoute] string courseId, [FromBody] CreateCourseLanguageViewModel request)
		{
			var command = request.ToCommand(instituteId, fieldId, courseId);

			var course = await _mediator.Send(command);

			return CourseLanguageViewModel.Create(course);
		}
		/// <summary>
		/// Get Course Languages list
		/// </summary>
		/// <param name="request"></param>
		/// <response code="200">Successfully get entities</response>
		/// <response code="400">Entity has missing/invalid values</response>
		/// <response code="404">Entity not found</response>
		[HttpGet("/institute/{instituteId:required}/field/{fieldId:required}/course/{courseId:required}/language")]
		public async Task<ActionResult<Pagination<CourseLanguageViewModel>>> GetCourseLanguageListAsync([FromRoute] string instituteId, [FromRoute] string fieldId, [FromRoute] string courseId, [FromQuery] GetListRequest request)
		{
			var query = new GetAllCourseLanguagesQuery(instituteId, fieldId, courseId, request.Offset, request.Count, request.Keyword);

			var courseLanguages = await _mediator.Send(query, HttpContext.RequestAborted);

			return courseLanguages.Map();
		}
		
		/// <summary>
		/// Delete Course Language entity
		/// </summary>
		/// <param name="id"></param>
		/// <response code="201" >Entity created</response>
		/// <response code="400">Entity has missing/invalid values</response>
		[HttpDelete("/institute/{instituteId:required}/field/{fieldId:required}/course/{courseId:required}/language/{courseLanguageId:required}")]
		public async Task<ActionResult> DeleteCourseLanguageAsync([FromRoute] string instituteId, [FromRoute] string fieldId, [FromRoute] string courseId, [FromRoute] string courseLanguageId)
		{
			var command = new DeleteCourseLanguageCommand(instituteId, fieldId, courseId, courseLanguageId);

			await _mediator.Send(command);

			return NoContent();
		}
	}
}
