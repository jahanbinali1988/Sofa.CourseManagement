using Microsoft.AspNetCore.Mvc;
using Sofa.CourseManagement.RestApi.Models;
using Sofa.CourseManagement.RestApi.Models.Sessions;
using Sofa.CourseManagement.Application.Contract.Sessions.Commands;
using Sofa.CourseManagement.Application.Contract.Sessions.Queries;
using Sofa.CourseManagement.SharedKernel.Application;

namespace Sofa.CourseManagement.RestApi.Controllers
{
	public partial class InstituteController
	{

		/// <summary>
		/// Create Session entity
		/// </summary>
		/// <param name="request"></param>
		/// <response code="201" >Entity created</response>
		/// <response code="400">Entity has missing/invalid values</response>
		[HttpPost("/institute/{instituteId:required}/field/{fieldId:required}/course/{courseId:required}/session")]
		public async Task<ActionResult<SessionViewModel>> CreateSessionAsync([FromRoute] string instituteId, [FromRoute] string fieldId,
			[FromRoute] string courseId, [FromBody] CreateSessionViewModel request)
		{
			var command = request.ToCommand(instituteId, fieldId, courseId);

			var session = await _mediator.Send(command);

			return SessionViewModel.Create(session);
		}

		/// <summary>
		/// Get Session by Id
		/// </summary>
		/// <param name="id"></param>
		/// <response code="200">Successfully get entity</response>
		/// <response code="400">Entity has missing/invalid values</response>
		/// <response code="404">Entity not found</response>
		[HttpGet("/institute/{instituteId:required}/field/{fieldId:required}/course/{courseId:required}/session/{sessionId:required}")]
		public async Task<ActionResult<SessionViewModel>> GetSessionByIdAsync([FromRoute] string instituteId, [FromRoute] string fieldId,
			[FromRoute] string courseId, [FromRoute] string sessionId)
		{
			var query = new GetSessionByIdQuery(instituteId, fieldId, courseId, sessionId);

			var session = await _mediator.Send(query, HttpContext.RequestAborted);

			return SessionViewModel.Create(session);
		}

		/// <summary>
		/// Get Sessions list
		/// </summary>
		/// <param name="request"></param>
		/// <response code="200">Successfully get entities</response>
		/// <response code="400">Entity has missing/invalid values</response>
		/// <response code="404">Entity not found</response>
		[HttpGet("/institute/{instituteId:required}/field/{fieldId:required}/course/{courseId:required}/session")]
		public async Task<ActionResult<Pagination<SessionViewModel>>> GetSessionListAsync([FromRoute] string instituteId, [FromRoute] string fieldId,
			[FromRoute] string courseId, [FromQuery] GetListRequest request)
		{
			var query = new GetAllSessionsQuery(instituteId, fieldId, courseId, request.Offset, request.Count, request.Keyword);

			var sessions = await _mediator.Send(query, HttpContext.RequestAborted);

			return sessions.Map();
		}

		/// <summary>
		/// Create Session entity
		/// </summary>
		/// <param name="id"></param>
		/// <param name="request"></param>
		/// <response code="201" >Entity created</response>
		/// <response code="400">Entity has missing/invalid values</response>
		[HttpPut("/institute/{instituteId:required}/field/{fieldId:required}/course/{courseId:required}/session/{sessionId:required}")]
		public async Task<ActionResult<SessionViewModel>> UpdateSessionAsync([FromRoute] string instituteId, [FromRoute] string fieldId,
			[FromRoute] string courseId, [FromRoute] string sessionId, [FromBody] CreateSessionViewModel request)
		{
			var command = request.ToCommand(instituteId, fieldId, courseId, sessionId);

			await _mediator.Send(command);

			return Ok();
		}

		/// <summary>
		/// Create Session entity
		/// </summary>
		/// <param name="id"></param>
		/// <response code="201" >Entity created</response>
		/// <response code="400">Entity has missing/invalid values</response>
		[HttpDelete("/institute/{instituteId:required}/field/{fieldId:required}/course/{courseId:required}/session/{sessionId:required}")]
		public async Task<ActionResult> DeleteSessionAsync([FromRoute] string instituteId, [FromRoute] string fieldId, 
			[FromRoute] string courseId, [FromRoute] string sessionId)
		{
			var command = new DeleteSessionCommand(instituteId, fieldId, courseId, sessionId);
			
			await _mediator.Send(command);

			return NoContent();
		}
	}
}
