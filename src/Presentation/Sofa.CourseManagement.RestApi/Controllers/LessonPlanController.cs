using Microsoft.AspNetCore.Mvc;
using Sofa.CourseManagement.RestApi.Models.LessonPlans;
using Sofa.CourseManagement.Application.Contract.LessonPlans.Commands;
using Sofa.CourseManagement.Application.Contract.LessonPlans.Queries;
using Sofa.CourseManagement.RestApi.Models.Sessions;
using Sofa.CourseManagement.RestApi.Models;
using Sofa.CourseManagement.RestApi.Models.Courses;
using Sofa.CourseManagement.SharedKernel.Application;

namespace Sofa.CourseManagement.RestApi.Controllers
{
	public partial class InstituteController 
	{
		/// <summary>
		/// Create LessonPlan entity
		/// </summary>
		/// <param name="request"></param>
		/// <response code="201" >Entity created</response>
		/// <response code="400">Entity has missing/invalid values</response>
		[HttpPost("/institute/{instituteId:required}/field/{fieldId:required}/course/{courseId:required}/session/{sessionId:required}/lessonplan")]
		public async Task<ActionResult<LessonPlanViewModel>> CreateAsync([FromRoute] string instituteId, [FromRoute] string fieldId,
			[FromRoute] string courseId, [FromRoute] string sessionId, [FromBody] CreateLessonPlanViewModel request)
		{
			var command = request.ToCommand(instituteId, fieldId, courseId, sessionId);

			var lessonPlan = await _mediator.Send(command);

			return LessonPlanViewModel.Create(lessonPlan);
		}

		/// <summary>
		/// Get LessonPlan by Id
		/// </summary>
		/// <param name="id"></param>
		/// <response code="200">Successfully get entity</response>
		/// <response code="400">Entity has missing/invalid values</response>
		/// <response code="404">Entity not found</response>
		[HttpGet("/institute/{instituteId:required}/field/{fieldId:required}/course/{courseId:required}/session/{sessionId:required}/lessonplan/{lessonplanId:required}")]
		public async Task<ActionResult<LessonPlanViewModel>> GetLessonPlanByIdAsync([FromRoute] string instituteId, [FromRoute] string fieldId,
			[FromRoute] string courseId, [FromRoute] string sessionId, [FromRoute] string lessonplanId)
		{
			var query = new GetLessonPlanByIdQuery(instituteId, fieldId, courseId, sessionId, lessonplanId);

			var lessonPlan = await _mediator.Send(query, HttpContext.RequestAborted);

			return LessonPlanViewModel.Create(lessonPlan);
		}


		/// <summary>
		/// Get LessonPlan list
		/// </summary>
		/// <param name="request"></param>
		/// <response code="200">Successfully get entities</response>
		/// <response code="400">Entity has missing/invalid values</response>
		/// <response code="404">Entity not found</response>
		[HttpGet("/institute/{instituteId:required}/field/{fieldId:required}/course/{courseId:required}/session/{sessionId:required}/lessonplan/")]
		public async Task<ActionResult<Pagination<LessonPlanViewModel>>> GetSessionListAsync([FromRoute] string instituteId, [FromRoute] string fieldId,
			[FromRoute] string courseId, [FromRoute] string sessionId, [FromQuery] GetListRequest request)
		{
			var query = new GetAllLessonPlansQuery(instituteId, fieldId, courseId, sessionId, request.Offset, request.Count, request.Keyword);

			var lessonPlans = await _mediator.Send(query, HttpContext.RequestAborted);

			return lessonPlans.Map();
		}


		/// <summary>
		/// Update LessonPlan entity
		/// </summary>
		/// <param name="id"></param>
		/// <param name="request"></param>
		/// <response code="201" >Entity created</response>
		/// <response code="400">Entity has missing/invalid values</response>
		[HttpPut("/institute/{instituteId:required}/field/{fieldId:required}/course/{courseId:required}/session/{sessionId:required}/lessonplan/{lessonplanId:required}")]
		public async Task<ActionResult<LessonPlanViewModel>> UpdateAsync([FromRoute] string instituteId, [FromRoute] string fieldId,
			[FromRoute] string courseId, [FromRoute] string sessionId, [FromRoute] string lessonplanId, [FromBody] CreateLessonPlanViewModel request)
		{
			var command = request.ToCommand(instituteId, fieldId, courseId, sessionId, lessonplanId);

			var lessonPlan = await _mediator.Send(command);

			return Ok();
		}

		/// <summary>
		/// Delete LessonPlan entity
		/// </summary>
		/// <param name="id"></param>
		/// <response code="201" >Entity created</response>
		/// <response code="400">Entity has missing/invalid values</response>
		[HttpDelete("/institute/{instituteId:required}/field/{fieldId:required}/course/{courseId:required}/session/{sessionId:required}/lessonplan/{lessonplanId:required}")]
		public async Task<ActionResult> DeleteAsync([FromRoute] string instituteId, [FromRoute] string fieldId,
			[FromRoute] string courseId, [FromRoute] string sessionId, [FromRoute] string lessonplanId)
		{
			var command = new DeleteLessonPlanCommand(instituteId, fieldId, courseId, sessionId, lessonplanId);
			
			await _mediator.Send(command);

			return NoContent();
		}
	}
}
