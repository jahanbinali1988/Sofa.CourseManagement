using Microsoft.AspNetCore.Mvc;
using Sofa.CourseManagement.Application.Contract.FieldQuestions.Commands;
using Sofa.CourseManagement.Application.Contract.FieldQuestions.Queries;
using Sofa.CourseManagement.RestApi.Models;
using Sofa.CourseManagement.RestApi.Models.Fields;
using Sofa.CourseManagement.SharedKernel.Application;

namespace Sofa.CourseManagement.RestApi.Controllers
{
	public partial class InstituteController
	{
		/// <summary>
		/// Create Field Question entity
		/// </summary>
		/// <param name="request"></param>
		/// <response code="201" >Entity created</response>
		/// <response code="400">Entity has missing/invalid values</response>
		[HttpPost("/institute/{instituteId:required}/field/{fieldId:required}/question")]
		public async Task<ActionResult<FieldQuestionViewModel>> CreateFieldQuestionAsync([FromRoute] string instituteId, [FromRoute] string questionId, [FromBody] CreateFieldQuestionViewModel request)
		{
			var command = request.ToCommand(instituteId, questionId);

			var fieldQuestion = await _mediator.Send(command);

			return FieldQuestionViewModel.Create(fieldQuestion);
		}

		/// <summary>
		/// Get Field Question by Id
		/// </summary>
		/// <param name="id"></param>
		/// <response code="200">Successfully get entity</response>
		/// <response code="400">Entity has missing/invalid values</response>
		/// <response code="404">Entity not found</response>
		[HttpGet("/institute/{instituteId:required}/field/{fieldId:required}/question/{questionId:required}")]
		public async Task<ActionResult<FieldQuestionViewModel>> GetFieldQuestionByIdAsync([FromRoute] string instituteId, [FromRoute] string fieldId, [FromRoute] string questionId)
		{
			var query = new GetFieldQuestionByIdQuery(instituteId, fieldId, questionId);

			var fieldQuestion = await _mediator.Send(query, HttpContext.RequestAborted);

			return FieldQuestionViewModel.Create(fieldQuestion);
		}

		/// <summary>
		/// Get Field Questions list
		/// </summary>
		/// <param name="request"></param>
		/// <response code="200">Successfully get entities</response>
		/// <response code="400">Entity has missing/invalid values</response>
		/// <response code="404">Entity not found</response>
		[HttpGet("/institute/{instituteId:required}/field/{feildId:required}/question")]
		public async Task<ActionResult<Pagination<FieldQuestionViewModel>>> GetFieldQuestionListAsync([FromRoute] string instituteId, [FromRoute] string fieldId, [FromQuery] GetListRequest request)
		{
			var query = new GetAllFieldQuestionsQuery(instituteId, fieldId, request.Offset, request.Count, request.Keyword);

			var fieldQuestions = await _mediator.Send(query, HttpContext.RequestAborted);

			return fieldQuestions.Map();
		}

		/// <summary>
		/// Create Field Question entity
		/// </summary>
		/// <param name="id"></param>
		/// <param name="request"></param>
		/// <response code="201" >Entity created</response>
		/// <response code="400">Entity has missing/invalid values</response>
		[HttpPut("/institute/{instituteId:required}/field/{fieldId:required}/question/{questionId:required}")]
		public async Task<ActionResult<FieldQuestionViewModel>> UpdateFieldQuestionAsync([FromRoute] string instituteId, [FromRoute] string fieldId, [FromRoute] string questionId, [FromBody] CreateFieldQuestionViewModel request)
		{
			var command = request.ToCommand(instituteId, fieldId, questionId);

			await _mediator.Send(command);

			return Ok();
		}

		/// <summary>
		/// Create Field Question entity
		/// </summary>
		/// <param name="id"></param>
		/// <response code="201" >Entity created</response>
		/// <response code="400">Entity has missing/invalid values</response>
		[HttpDelete("/institute/{instituteId:required}/field/{fieldId:required}/question/{questionId:required}")]
		public async Task<ActionResult> DeleteFieldQuestionAsync([FromRoute] string instituteId, [FromRoute] string fieldId, [FromRoute] string questionId)
		{
			var command = new DeleteFieldQuestionCommand(instituteId, fieldId, questionId);

			await _mediator.Send(command);

			return NoContent();
		}
	}
}
