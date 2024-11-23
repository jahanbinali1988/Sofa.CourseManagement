using Microsoft.AspNetCore.Mvc;
using Sofa.CourseManagement.RestApi.Models;
using Sofa.CourseManagement.RestApi.Models.Terms;
using Sofa.CourseManagement.Application.Contract.Terms.Commands;
using Sofa.CourseManagement.Application.Contract.Terms.Dtos;
using Sofa.CourseManagement.Application.Contract.Terms.Queries;
using Sofa.CourseManagement.Domain.Institutes.Entities;
using Sofa.CourseManagement.Application.Contract.UserTerms.Commands;
using Sofa.CourseManagement.Application.Contract.UserTerms.Dtos;
using Sofa.CourseManagement.Application.Contract.UserTerms.Queries;
using Sofa.CourseManagement.RestApi.Models.UserTerms;

namespace Sofa.CourseManagement.RestApi.Controllers
{
	public partial class InstituteController
	{
		/// <summary>
		/// Create Term entity
		/// </summary>
		/// <param name="request"></param>
		/// <response code="201" >Entity created</response>
		/// <response code="400">Entity has missing/invalid values</response>
		[HttpPost("/institute/{instituteId:required}/field/{fieldId:required}/course/{courseId:required}/term")]
		public async Task<ActionResult<TermViewModel>> CreateTermAsync([FromQuery] string instituteId, [FromQuery] string fieldId, 
			[FromQuery] string courseId, [FromBody] CreateTermViewModel request)
		{
			var command = request.ToCommand(instituteId, fieldId, courseId);

			var term = await _mediator.Send(command);

			return Created(TermViewModel.Create(term));
		}

		/// <summary>
		/// Get Term by Id
		/// </summary>
		/// <param name="id"></param>
		/// <response code="200">Successfully get entity</response>
		/// <response code="400">Entity has missing/invalid values</response>
		/// <response code="404">Entity not found</response>
		[HttpGet("/institute/{instituteId:required}/field/{fieldId:required}/course/{courseId:required}/term/{id:required}")]
		public async Task<ActionResult<TermViewModel>> GetTermByIdAsync([FromQuery] string instituteId, [FromQuery] string fieldId, 
			[FromQuery] string courseId, [FromQuery] string termId)
		{
			var query = new GetTermByIdQuery(instituteId, fieldId, courseId, termId);

			var term = await _mediator.Send(query, HttpContext.RequestAborted);

			return Get<TermViewModel>(TermViewModel.Create(term));
		}

		/// <summary>
		/// Get Terms list
		/// </summary>
		/// <param name="request"></param>
		/// <response code="200">Successfully get entities</response>
		/// <response code="400">Entity has missing/invalid values</response>
		/// <response code="404">Entity not found</response>
		[HttpGet("/institute/{instituteId:required}/field/{fieldId:required}/course/{courseId:required}/term")]
		public async Task<ActionResult<IEnumerable<TermViewModel>>> GetTermListAsync([FromQuery] string instituteId, 
			[FromQuery] string fieldId, [FromQuery] string courseId, [FromQuery] GetListRequest request)
		{
			var query = new GetAllTermsQuery(instituteId, fieldId, courseId, request.Offset, request.Count, request.Keyword);

			var terms = await _mediator.Send(query, HttpContext.RequestAborted);

			return List<TermDto, TermViewModel>(terms);
		}

		/// <summary>
		/// Create Term entity
		/// </summary>
		/// <param name="id"></param>
		/// <param name="request"></param>
		/// <response code="201" >Entity created</response>
		/// <response code="400">Entity has missing/invalid values</response>
		[HttpPut("/institute/{instituteId:required}/field/{fieldId:required}/course/{courseId:required}/term/{termId:required}")]
		public async Task<ActionResult<TermViewModel>> UpdateTermAsync([FromQuery] string instituteId, [FromQuery] string fieldId, 
			[FromQuery] string courseId, [FromQuery] string termId, [FromBody] CreateTermViewModel request)
		{
			var command = request.ToCommand(instituteId, fieldId, courseId, termId);

			await _mediator.Send(command);

			return Ok();
		}

		/// <summary>
		/// Create Term entity
		/// </summary>
		/// <param name="id"></param>
		/// <response code="201" >Entity created</response>
		/// <response code="400">Entity has missing/invalid values</response>
		[HttpDelete("/institute/{instituteId:required}/field/{fieldId:required}/course/{courseId:required}/term/{termId:required}")]
		public async Task<ActionResult> DeleteTermAsync([FromQuery] string instituteId, [FromQuery] string fieldId, 
			[FromQuery] string courseId, [FromQuery] string termId)
		{
			var command = new DeleteTermCommand(instituteId, fieldId, courseId, termId);
			
			await _mediator.Send(command);

			return NoContent();
		}

		/// <summary>
		/// Get User Terms list
		/// </summary>
		/// <param name="request"></param>
		/// <response code="200">Successfully get entities</response>
		/// <response code="400">Entity has missing/invalid values</response>
		/// <response code="404">Entity not found</response>
		[HttpGet("/institute/{instituteId:required}/field/{fieldId:required}/course/{courseId:required}/term/{termId:required}/user")]
		public async Task<ActionResult<IEnumerable<UserTermViewModel>>> GetUserTermListAsync([FromQuery] string instituteId, 
			[FromQuery] string fieldId, [FromQuery] string courseId, [FromQuery] string termId, [FromQuery] GetListRequest request)
		{
			var query = new GetAllUserTermsQuery(request.Offset, request.Count, request.Keyword, instituteId, fieldId, courseId, termId);

			var users = await _mediator.Send(query, HttpContext.RequestAborted);

			return List<UserTermDto, UserTermViewModel>(users);
		}

		/// <summary>
		/// Add Term to User entity
		/// </summary>
		/// <param name="id"></param>
		/// <param name="request"></param>
		/// <response code="201" >Entity created</response>
		/// <response code="400">Entity has missing/invalid values</response>
		[HttpPut("/institute/{instituteId:required}/field/{fieldId:required}/course/{courseId:required}/term/{termId:required}/user")]
		public async Task<ActionResult<UserTermViewModel>> AddUserToTermAsync([FromQuery] string instituteId, [FromQuery] string fieldId, 
			[FromQuery] string courseId, [FromQuery] string termId, [FromBody] string userId)
		{
			var command = new AddUserTermCommand(instituteId, fieldId, courseId, termId, userId);

			await _mediator.Send(command);

			return Ok();
		}

		/// <summary>
		/// Remove Term from User entity
		/// </summary>
		/// <param name="id"></param>
		/// <param name="request"></param>
		/// <response code="201" >Entity created</response>
		/// <response code="400">Entity has missing/invalid values</response>
		[HttpDelete("/institute/{instituteId:required}/field/{fieldId:required}/course/{courseId:required}/term/{termId:required}/user/{userId:required}")]
		public async Task<ActionResult> RemoveUserFromTermAsync([FromQuery] string instituteId, [FromQuery] string fieldId, 
			[FromQuery] string courseId, [FromQuery] string termId, [FromQuery] string userId)
		{
			var command = new DeleteUserTermCommand(instituteId, fieldId, courseId, termId, userId);

			await _mediator.Send(command);

			return Ok();
		}

	}
}
