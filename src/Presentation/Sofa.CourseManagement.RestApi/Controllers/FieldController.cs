using Microsoft.AspNetCore.Mvc;
using Sofa.CourseManagement.RestApi.Models;
using Sofa.CourseManagement.RestApi.Models.Fields;
using Sofa.CourseManagement.Application.Contract.Fields.Commands;
using Sofa.CourseManagement.Application.Contract.Fields.Dtos;
using Sofa.CourseManagement.Application.Contract.Fields.Queries;

namespace Sofa.CourseManagement.RestApi.Controllers
{
	public partial class InstituteController
	{
		/// <summary>
		/// Create Field entity
		/// </summary>
		/// <param name="request"></param>
		/// <response code="201" >Entity created</response>
		/// <response code="400">Entity has missing/invalid values</response>
		[HttpPost("/institute/{instituteId:required}/field")]
		public async Task<ActionResult<FieldViewModel>> CreateFieldAsync([FromQuery] string instituteId, [FromBody] CreateFieldViewModel request)
		{
			var command = request.ToCommand(instituteId);

			var field = await _mediator.Send(command);
			
			return Created(FieldViewModel.Create(field));
		}

		/// <summary>
		/// Get Field by Id
		/// </summary>
		/// <param name="id"></param>
		/// <response code="200">Successfully get entity</response>
		/// <response code="400">Entity has missing/invalid values</response>
		/// <response code="404">Entity not found</response>
		[HttpGet("/institute/{instituteId:required}/field/{fieldId:required}")]
		public async Task<ActionResult<FieldViewModel>> GetFieldByIdAsync([FromQuery] string instituteId, [FromQuery] string fieldId)
		{
			var query = new GetFieldByIdQuery(instituteId, fieldId);

			var field = await _mediator.Send(query, HttpContext.RequestAborted);

			return Get<FieldViewModel>(FieldViewModel.Create(field));
		}

		/// <summary>
		/// Get Fields list
		/// </summary>
		/// <param name="request"></param>
		/// <response code="200">Successfully get entities</response>
		/// <response code="400">Entity has missing/invalid values</response>
		/// <response code="404">Entity not found</response>
		[HttpGet("/institute/{instituteId:required}/field")]
		public async Task<ActionResult<IEnumerable<FieldViewModel>>> GetFieldListAsync([FromQuery] string instituteId, [FromQuery] GetListRequest request)
		{
			var query = new GetAllFieldsQuery(instituteId, request.Offset, request.Count, request.Keyword);

			var fields = await _mediator.Send(query, HttpContext.RequestAborted);

			return List<FieldDto, FieldViewModel>(fields);
		}

		/// <summary>
		/// Create Field entity
		/// </summary>
		/// <param name="id"></param>
		/// <param name="request"></param>
		/// <response code="201" >Entity created</response>
		/// <response code="400">Entity has missing/invalid values</response>
		[HttpPut("/institute/{instituteId:required}/field/{fieldId:required}")]
		public async Task<ActionResult<FieldViewModel>> UpdateFieldAsync([FromQuery] string instituteId, [FromQuery] string fieldId, [FromBody] CreateFieldViewModel request)
		{
			var command = request.ToCommand(instituteId, fieldId);

			await _mediator.Send(command);

			return Ok();
		}

		/// <summary>
		/// Create Field entity
		/// </summary>
		/// <param name="id"></param>
		/// <response code="201" >Entity created</response>
		/// <response code="400">Entity has missing/invalid values</response>
		[HttpDelete("/institute/{instituteId:required}/field/{fieldId:required}")]
		public async Task<ActionResult> DeleteFieldAsync([FromQuery] string instituteId, [FromQuery] string fieldId)
		{
			var command = new DeleteFieldCommand(instituteId, fieldId);
			
			await _mediator.Send(command);

			return NoContent();
		}
	}
}
