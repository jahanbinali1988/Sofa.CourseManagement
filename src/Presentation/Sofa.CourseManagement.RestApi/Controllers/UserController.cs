﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sofa.CourseManagement.Application.Contract.InstituteUsers.Commands;
using Sofa.CourseManagement.Application.Contract.InstituteUsers.Dtos;
using Sofa.CourseManagement.Application.Contract.InstituteUsers.Queries;
using Sofa.CourseManagement.Application.Contract.Users.Commands;
using Sofa.CourseManagement.Application.Contract.Users.Dtos;
using Sofa.CourseManagement.Application.Contract.Users.Queries;
using Sofa.CourseManagement.Application.Contract.UserTerms.Commands;
using Sofa.CourseManagement.Application.Contract.UserTerms.Dtos;
using Sofa.CourseManagement.Application.Contract.UserTerms.Queries;
using Sofa.CourseManagement.RestApi.Models;
using Sofa.CourseManagement.RestApi.Models.InstituteUsers;
using Sofa.CourseManagement.RestApi.Models.Users;
using Sofa.CourseManagement.RestApi.Models.UserTerms;

namespace Sofa.CourseManagement.RestApi.Controllers
{

	[ApiController]
	[Route("user")]
	public class UserController : BaseController
	{
		private readonly ILogger<UserController> _logger;

		private readonly IMediator _mediator;
		public UserController(IMediator mediator, ILogger<UserController> logger) : base(logger)
		{
			_mediator = mediator;
			_logger = logger;
		}

		/// <summary>
		/// Create User entity
		/// </summary>
		/// <param name="request"></param>
		/// <response code="201" >Entity created</response>
		/// <response code="400">Entity has missing/invalid values</response>
		[HttpPost("/user")]
		public async Task<ActionResult<UserViewModel>> CreateUserAsync([FromBody] CreateUserViewModel request)
		{
			var command = request.ToCommand();

			var user = await _mediator.Send(command);

			return Created(UserViewModel.Create(user));
		}

		/// <summary>
		/// Get User by Id
		/// </summary>
		/// <param name="id"></param>
		/// <response code="200">Successfully get entity</response>
		/// <response code="400">Entity has missing/invalid values</response>
		/// <response code="404">Entity not found</response>
		[HttpGet("/user/{userId:required}")]
		public async Task<ActionResult<UserViewModel>> GetUserByIdAsync([FromQuery] Guid userId)
		{
			var query = new GetUserByIdQuery(userId);

			var user = await _mediator.Send(query, HttpContext.RequestAborted);

			return Get<UserViewModel>(UserViewModel.Create(user));
		}

		/// <summary>
		/// Get Users list
		/// </summary>
		/// <param name="request"></param>
		/// <response code="200">Successfully get entities</response>
		/// <response code="400">Entity has missing/invalid values</response>
		/// <response code="404">Entity not found</response>
		[HttpGet("/user")]
		public async Task<ActionResult<IEnumerable<UserViewModel>>> GetUserListAsync([FromQuery] GetListRequest request)
		{
			var query = new GetAllUsersQuery(request.Offset, request.Count, request.Keyword);

			var users = await _mediator.Send(query, HttpContext.RequestAborted);

			return List<UserDto, UserViewModel>(users);
		}

		/// <summary>
		/// Update User entity
		/// </summary>
		/// <param name="id"></param>
		/// <param name="request"></param>
		/// <response code="201" >Entity created</response>
		/// <response code="400">Entity has missing/invalid values</response>
		[HttpPut("/user/{userId:required}")]
		public async Task<ActionResult<UserViewModel>> UpdateUserAsync([FromQuery] Guid userId, [FromBody] CreateUserViewModel request)
		{
			var command = request.ToCommand(userId);

			await _mediator.Send(command);

			return Ok();
		}

		/// <summary>
		/// Update User Password entity
		/// </summary>
		/// <param name="id"></param>
		/// <param name="request"></param>
		/// <response code="201" >Entity created</response>
		/// <response code="400">Entity has missing/invalid values</response>
		[HttpPut("/user/{userId:required}/password")]
		public async Task<ActionResult> ChangeUserPasswordAsync([FromQuery] Guid userId, [FromBody] ChangeUserPasswordViewModel request)
		{
			var command = request.ToCommand(userId);

			await _mediator.Send(command);

			return Ok();
		}

		/// <summary>
		/// Create User entity
		/// </summary>
		/// <param name="id"></param>
		/// <response code="201" >Entity created</response>
		/// <response code="400">Entity has missing/invalid values</response>
		[HttpDelete("/user/{userId:required}")]
		public async Task<ActionResult> DeleteUserAsync([FromQuery] Guid userId)
		{
			var command = new DeleteUserCommand(userId);

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
		[HttpGet("/user/{userId:required}/term")]
		public async Task<ActionResult<IEnumerable<UserTermViewModel>>> GetUserTermListAsync([FromQuery] Guid userId, [FromQuery] GetListRequest request)
		{
			var query = new GetAllUserTermsQuery(request.Offset, request.Count, request.Keyword, userId);

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
		[HttpPut("/user/{userId:required}/term")]
		public async Task<ActionResult<UserTermViewModel>> AddTermToUserAsync([FromQuery] Guid userId, [FromBody] Guid termId)
		{
			var command = new AddUserTermCommand(termId, userId);

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
		[HttpDelete("/user/{userId:required}/term/{termId:required}/")]
		public async Task<ActionResult> RemoveTermFromUserAsync([FromQuery] Guid userId, [FromQuery] Guid termId)
		{
			var command = new DeleteUserTermCommand(termId, userId);

			await _mediator.Send(command);

			return Ok();
		}

		/// <summary>
		/// Get Institute Users list
		/// </summary>
		/// <param name="request"></param>
		/// <response code="200">Successfully get entities</response>
		/// <response code="400">Entity has missing/invalid values</response>
		/// <response code="404">Entity not found</response>
		[HttpGet("/user/{userId:required}/institute")]
		public async Task<ActionResult<IEnumerable<InstituteUserViewModel>>> GetInstituteUsersListAsync([FromQuery] Guid userId, [FromQuery] GetListRequest request)
		{
			var query = new GetAllInstituteUsersQuery(request.Offset, request.Count, request.Keyword, userId, null);

			var users = await _mediator.Send(query, HttpContext.RequestAborted);

			return List<InstituteUserDto, InstituteUserViewModel>(users);
		}

		/// <summary>
		/// Add Institute to User entity
		/// </summary>
		/// <param name="id"></param>
		/// <param name="request"></param>
		/// <response code="201" >Entity created</response>
		/// <response code="400">Entity has missing/invalid values</response>
		[HttpPut("/user/{userId:required}/institute")]
		public async Task<ActionResult<InstituteUserViewModel>> AddInstituteToUserAsync([FromQuery] Guid userId, [FromBody] Guid instituteId)
		{
			var command = new AddInstituteUserCommand(instituteId, userId);

			await _mediator.Send(command);

			return Ok();
		}

		/// <summary>
		/// Delete Institute from User entity
		/// </summary>
		/// <param name="id"></param>
		/// <param name="request"></param>
		/// <response code="201" >Entity created</response>
		/// <response code="400">Entity has missing/invalid values</response>
		[HttpDelete("/user/{userId:required}/institute/{instituteId:required}/")]
		public async Task<ActionResult> RemoveInstituteFromUserAsync([FromQuery] Guid userId, [FromQuery] Guid instituteId)
		{
			var command = new DeleteInstituteUserCommand(userId, instituteId);

			await _mediator.Send(command);

			return NoContent();
		}
	}
}