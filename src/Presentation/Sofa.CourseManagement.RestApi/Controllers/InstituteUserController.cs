using Microsoft.AspNetCore.Mvc;
using Sofa.CourseManagement.RestApi.Models.Fields;
using Sofa.CourseManagement.RestApi.Models;
using Sofa.CourseManagement.SharedKernel.Application;
using Sofa.CourseManagement.RestApi.Models.InstituteUsers;
using Sofa.CourseManagement.Application.Contract.InstituteUsers.Commands;
using Sofa.CourseManagement.Application.Contract.InstituteUsers.Queries;

namespace Sofa.CourseManagement.RestApi.Controllers
{
	public partial class InstituteController
	{

		/// <summary>
		/// Create Institute User entity
		/// </summary>
		/// <param name="request"></param>
		/// <response code="201" >Entity created</response>
		/// <response code="400">Entity has missing/invalid values</response>
		[HttpPut("/institute/{instituteId:required}/user")]
		public async Task<ActionResult<InstituteUserViewModel>> CreateInstituteUserAsync([FromQuery] string instituteId, [FromBody] CreateInstituteUserViewModel request)
		{
			var command = request.ToCommand(instituteId);

			var instituteUser = await _mediator.Send(command);

			return InstituteUserViewModel.Create(instituteUser);
		}

		/// <summary>
		/// Get Institute Users list
		/// </summary>
		/// <param name="request"></param>
		/// <response code="200">Successfully get entities</response>
		/// <response code="400">Entity has missing/invalid values</response>
		/// <response code="404">Entity not found</response>
		[HttpGet("/institute/{instituteId:required}/user")]
		public async Task<ActionResult<Pagination<InstituteUserViewModel>>> GetInstituteUserListAsync([FromQuery] string instituteId, [FromQuery] GetListRequest request)
		{
			var query = new GetAllInstituteUsersQuery(request.Offset, request.Count, request.Keyword, null, instituteId);

			var instituteUsers = await _mediator.Send(query, HttpContext.RequestAborted);

			return instituteUsers.Map();
		}

		/// <summary>
		/// Delete Institute User entity
		/// </summary>
		/// <param name="id"></param>
		/// <response code="201" >Entity created</response>
		/// <response code="400">Entity has missing/invalid values</response>
		[HttpDelete("/institute/{instituteId:required}/user/{userId:required}")]
		public async Task<ActionResult> DeleteInstituteUserAsync([FromQuery] string instituteId, [FromQuery] string userId)
		{
			var command = new DeleteInstituteUserCommand(userId, instituteId);

			await _mediator.Send(command);

			return NoContent();
		}
	}
}
