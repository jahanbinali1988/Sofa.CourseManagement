using Microsoft.AspNetCore.Mvc;
using Sofa.CourseManagement.RestApi.Models.Fields;
using Sofa.CourseManagement.RestApi.Models;
using Sofa.SharedKernel.Application;
using Sofa.CourseManagement.Application.Contract.FieldQuestionChoices.Queries;
using Sofa.CourseManagement.Application.Contract.FieldQuestionChoices.Commands;

namespace Sofa.CourseManagement.RestApi.Controllers
{
	public partial class InstituteController
	{
		/// <summary>
		/// Create Field Question Choice entity
		/// </summary>
		/// <param name="request"></param>
		/// <response code="201" >Entity created</response>
		/// <response code="400">Entity has missing/invalid values</response>
		[HttpPost("/institute/{instituteId:required}/field/{fieldId:required}/question/{questionId:required}/choice")]
		public async Task<ActionResult<FieldQuestionChoiceViewModel>> CreateFieldQuestionChoiceAsync([FromRoute] string instituteId, [FromRoute] string fieldId,
			[FromRoute] string questionId, [FromBody] CreateFieldQuestionChoiceViewModel request)
		{
			var command = request.ToCommand(instituteId, fieldId, questionId);

			var fieldQuestionChoice = await _mediator.Send(command);

			return FieldQuestionChoiceViewModel.Create(fieldQuestionChoice);
		}

		/// <summary>
		/// Get Field Question Choice by Id
		/// </summary>
		/// <param name="id"></param>
		/// <response code="200">Successfully get entity</response>
		/// <response code="400">Entity has missing/invalid values</response>
		/// <response code="404">Entity not found</response>
		[HttpGet("/institute/{instituteId:required}/field/{fieldId:required}/question/{questionId:required}/choice/{choiceId:required}")]
		public async Task<ActionResult<FieldQuestionChoiceViewModel>> GetFieldQuestionChoiceByIdAsync([FromRoute] string instituteId, [FromRoute] string fieldId, 
			[FromRoute] string questionId, [FromRoute] string choiceId)
		{
			var query = new GetFieldQuestionChoiceByIdQuery(instituteId, fieldId, questionId, choiceId);

			var fieldQuestionChoice = await _mediator.Send(query, HttpContext.RequestAborted);

			return FieldQuestionChoiceViewModel.Create(fieldQuestionChoice);
		}

		/// <summary>
		/// Get Field Question Choices list
		/// </summary>
		/// <param name="request"></param>
		/// <response code="200">Successfully get entities</response>
		/// <response code="400">Entity has missing/invalid values</response>
		/// <response code="404">Entity not found</response>
		[HttpGet("/institute/{instituteId:required}/field/{fieldId:required}/question/{questionId:required}/choice")]
		public async Task<ActionResult<Pagination<FieldQuestionChoiceViewModel>>> GetFieldQuestionChoiceListAsync([FromRoute] string instituteId, [FromRoute] string fieldId,
			[FromRoute] string questionId, [FromQuery] GetListRequest request)
		{
			var query = new GetAllFieldQuestionChoicesQuery(instituteId, fieldId, questionId, request.Offset, request.Count, request.Keyword);

			var fieldQuestionChoices = await _mediator.Send(query, HttpContext.RequestAborted);

			return fieldQuestionChoices.Map();
		}

		/// <summary>
		/// Update Field Question Choice entity
		/// </summary>
		/// <param name="id"></param>
		/// <param name="request"></param>
		/// <response code="201" >Entity updated</response>
		/// <response code="400">Entity has missing/invalid values</response>
		[HttpPut("/institute/{instituteId:required}/field/{fieldId:required}/question/{questionId:required}/choice/{choiceId:required}")]
		public async Task<ActionResult<FieldQuestionChoiceViewModel>> UpdateFieldQuestionChoiceAsync([FromRoute] string instituteId, [FromRoute] string fieldId, [FromRoute] string questionId,
			[FromRoute] string choiceId, [FromBody] CreateFieldQuestionChoiceViewModel request)
		{
			var command = request.ToCommand(instituteId, fieldId, questionId, choiceId);

			await _mediator.Send(command);

			return Ok();
		}

		/// <summary>
		/// Delete Field Question Choice entity
		/// </summary>
		/// <param name="id"></param>
		/// <response code="201" >Entity deleted</response>
		/// <response code="400">Entity has missing/invalid values</response>
		[HttpDelete("/institute/{instituteId:required}/field/{fieldId:required}/question/{questionId:required}/choice/{choiceId:required}")]
		public async Task<ActionResult> DeleteFieldQuestionChoiceAsync([FromRoute] string instituteId, [FromRoute] string fieldId, [FromRoute] string questionId, [FromRoute] string choiceId)
		{
			var command = new DeleteFieldQuestionChoiceCommand(instituteId, fieldId, questionId, choiceId);

			await _mediator.Send(command);

			return NoContent();
		}
	}
}
