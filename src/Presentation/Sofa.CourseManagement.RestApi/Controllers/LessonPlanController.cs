using Microsoft.AspNetCore.Mvc;
using Sofa.CourseManagement.RestApi.Models.LessonPlans;
using Sofa.CourseManagement.Application.Contract.LessonPlans.Commands;
using Sofa.CourseManagement.Application.Contract.LessonPlans.Queries;
using Sofa.CourseManagement.Application.Contract.Sessions.Dtos;
using Sofa.CourseManagement.Application.Contract.Sessions.Queries;
using Sofa.CourseManagement.RestApi.Models.Sessions;
using Sofa.CourseManagement.RestApi.Models;
using Sofa.CourseManagement.Application.Contract.LessonPlans.Dtos;

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
		[HttpPost("/institute/{instituteId:required}/field/{fieldId:required}/course/{courseId:required}/term/{termId:required}/session/{sessionId:required}/lessonplan")]
		public async Task<ActionResult<LessonPlanViewModel>> CreateAsync([FromQuery] string instituteId, [FromQuery] string fieldId,
			[FromQuery] string courseId, [FromQuery] string termId, [FromQuery] string sessionId, [FromBody] CreateLessonPlanViewModel request)
		{
			var command = request.ToCommand(instituteId, fieldId, courseId, termId, sessionId);

			var lessonPlan = await _mediator.Send(command);

			return Created(LessonPlanViewModel.Create(lessonPlan));
		}

		/// <summary>
		/// Get LessonPlan by Id
		/// </summary>
		/// <param name="id"></param>
		/// <response code="200">Successfully get entity</response>
		/// <response code="400">Entity has missing/invalid values</response>
		/// <response code="404">Entity not found</response>
		[HttpGet("/institute/{instituteId:required}/field/{fieldId:required}/course/{courseId:required}/term/{termId:required}/session/{sessionId:required}/lessonplan/{lessonplanId:required}")]
		public async Task<ActionResult<LessonPlanViewModel>> GetLessonPlanByIdAsync([FromQuery] string instituteId, [FromQuery] string fieldId,
			[FromQuery] string courseId, [FromQuery] string termId, [FromQuery] string sessionId, [FromQuery] string lessonplanId)
		{
			var query = new GetLessonPlanByIdQuery(instituteId, fieldId, courseId, termId, sessionId, lessonplanId);

			var lessonPlan = await _mediator.Send(query, HttpContext.RequestAborted);

			return Get<LessonPlanViewModel>(LessonPlanViewModel.Create(lessonPlan));
		}


		/// <summary>
		/// Get LessonPlan list
		/// </summary>
		/// <param name="request"></param>
		/// <response code="200">Successfully get entities</response>
		/// <response code="400">Entity has missing/invalid values</response>
		/// <response code="404">Entity not found</response>
		[HttpGet("/institute/{instituteId:required}/field/{fieldId:required}/course/{courseId:required}/term/{termId:required}/session/{sessionId:required}/lessonplan/")]
		public async Task<ActionResult<LessonPlanViewModel>> GetSessionListAsync([FromQuery] string instituteId, [FromQuery] string fieldId,
			[FromQuery] string courseId, [FromQuery] string termId, [FromQuery] string sessionId, [FromQuery] GetListRequest request)
		{
			var query = new GetAllLessonPlansQuery(instituteId, fieldId, courseId, termId, sessionId, request.Offset, request.Count, request.Keyword);

			var lessonPlan = await _mediator.Send(query, HttpContext.RequestAborted);

			return Get<LessonPlanViewModel>(LessonPlanViewModel.Create(lessonPlan));
		}


		/// <summary>
		/// Update LessonPlan entity
		/// </summary>
		/// <param name="id"></param>
		/// <param name="request"></param>
		/// <response code="201" >Entity created</response>
		/// <response code="400">Entity has missing/invalid values</response>
		[HttpPut("/institute/{instituteId:required}/field/{fieldId:required}/course/{courseId:required}/term/{termId:required}/session/{sessionId:required}/lessonplan/{lessonplanId:required}")]
		public async Task<ActionResult<LessonPlanViewModel>> UpdateAsync([FromQuery] string instituteId, [FromQuery] string fieldId,
			[FromQuery] string courseId, [FromQuery] string termId, [FromQuery] string sessionId, [FromQuery] string lessonplanId, [FromBody] CreateLessonPlanViewModel request)
		{
			var command = request.ToCommand(instituteId, fieldId, courseId, termId, sessionId, lessonplanId);

			var lessonPlan = await _mediator.Send(command);

			return Ok();
		}

		/// <summary>
		/// Create LessonPlan entity
		/// </summary>
		/// <param name="id"></param>
		/// <response code="201" >Entity created</response>
		/// <response code="400">Entity has missing/invalid values</response>
		[HttpDelete("/institute/{instituteId:required}/field/{fieldId:required}/course/{courseId:required}/term/{termId:required}/session/{sessionId:required}/lessonplan/{lessonplanId:required}")]
		public async Task<ActionResult> DeleteAsync([FromQuery] string instituteId, [FromQuery] string fieldId,
			[FromQuery] string courseId, [FromQuery] string termId, [FromQuery] string sessionId, [FromQuery] string lessonplanId)
		{
			var command = new DeleteLessonPlanCommand(instituteId, fieldId, courseId, termId, sessionId, lessonplanId);
			var lessonPlan = await _mediator.Send(command);

			return NoContent();
		}
	}
}
