﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sofa.CourseManagement.Application.Contract.CourseUsers.Commands;
using Sofa.CourseManagement.Application.Contract.CourseUsers.Queries;
using Sofa.CourseManagement.Application.Contract.InstituteUsers.Commands;
using Sofa.CourseManagement.Application.Contract.InstituteUsers.Queries;
using Sofa.CourseManagement.Application.Contract.Users.Commands;
using Sofa.CourseManagement.Application.Contract.Users.Queries;
using Sofa.CourseManagement.RestApi.Models;
using Sofa.CourseManagement.RestApi.Models.InstituteUsers;
using Sofa.CourseManagement.RestApi.Models.Users;
using Sofa.CourseManagement.RestApi.Models.UserTerms;
using Sofa.CourseManagement.SharedKernel.Application;

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

			return UserViewModel.Create(user);
		}

		/// <summary>
		/// Get User by Id
		/// </summary>
		/// <param name="id"></param>
		/// <response code="200">Successfully get entity</response>
		/// <response code="400">Entity has missing/invalid values</response>
		/// <response code="404">Entity not found</response>
		[HttpGet("/user/{userId:required}")]
		public async Task<ActionResult<UserViewModel>> GetUserByIdAsync([FromRoute] string userId)
		{
			var query = new GetUserByIdQuery(userId);

			var user = await _mediator.Send(query, HttpContext.RequestAborted);

			return UserViewModel.Create(user);
		}

		/// <summary>
		/// Get Users list
		/// </summary>
		/// <param name="request"></param>
		/// <response code="200">Successfully get entities</response>
		/// <response code="400">Entity has missing/invalid values</response>
		/// <response code="404">Entity not found</response>
		[HttpGet("/user")]
		public async Task<ActionResult<Pagination<UserViewModel>>> GetUserListAsync([FromQuery] GetListRequest request)
		{
			var query = new GetAllUsersQuery(request.Offset, request.Count, request.Keyword);

			var users = await _mediator.Send(query, HttpContext.RequestAborted);

			return users.Map();
		}

		/// <summary>
		/// Update User entity
		/// </summary>
		/// <param name="id"></param>
		/// <param name="request"></param>
		/// <response code="201" >Entity created</response>
		/// <response code="400">Entity has missing/invalid values</response>
		[HttpPut("/user/{userId:required}")]
		public async Task<ActionResult<UserViewModel>> UpdateUserAsync([FromRoute] string userId, [FromBody] CreateUserViewModel request)
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
		public async Task<ActionResult> ChangeUserPasswordAsync([FromRoute] string userId, [FromBody] ChangeUserPasswordViewModel request)
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
		public async Task<ActionResult> DeleteUserAsync([FromRoute] string userId)
		{
			var command = new DeleteUserCommand(userId);

			await _mediator.Send(command);

			return NoContent();
		}

		/// <summary>
		/// Get User Courses list
		/// </summary>
		/// <param name="request"></param>
		/// <response code="200">Successfully get entities</response>
		/// <response code="400">Entity has missing/invalid values</response>
		/// <response code="404">Entity not found</response>
		[HttpGet("/user/{userId:required}/course")]
		public async Task<ActionResult<Pagination<UserCourseViewModel>>> GetUserCourseistAsync([FromRoute] string userId, [FromQuery] GetListRequest request)
		{
			var query = new GetAllCourseUsersQuery(request.Offset, request.Count, request.Keyword, userId);

			var userCourses = await _mediator.Send(query, HttpContext.RequestAborted);

			return userCourses.Map();
		}

		/// <summary>
		/// Add Course to User entity
		/// </summary>
		/// <param name="id"></param>
		/// <param name="request"></param>
		/// <response code="201" >Entity created</response>
		/// <response code="400">Entity has missing/invalid values</response>
		[HttpPut("/user/{userId:required}/course/{courseId:required}")]
		public async Task<ActionResult<UserCourseViewModel>> AddCourseToUserAsync([FromRoute] string userId, [FromBody] string courseId)
		{
			var command = new AddCourseUserCommand(courseId, userId);

			await _mediator.Send(command);

			return Ok();
		}

		/// <summary>
		/// Remove Course from User entity
		/// </summary>
		/// <param name="id"></param>
		/// <param name="request"></param>
		/// <response code="201" >Entity created</response>
		/// <response code="400">Entity has missing/invalid values</response>
		[HttpDelete("/user/{userId:required}/course/{courseId:required}/")]
		public async Task<ActionResult> RemoveCourseFromUserAsync([FromRoute] string userId, [FromRoute] string courseId)
		{
			var command = new DeleteCourseUserCommand(courseId, userId);

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
		public async Task<ActionResult<Pagination<InstituteUserViewModel>>> GetInstituteUsersListAsync([FromRoute] string userId, [FromQuery] GetListRequest request)
		{
			var query = new GetAllInstituteUsersQuery(request.Offset, request.Count, request.Keyword, userId, null);

			var users = await _mediator.Send(query, HttpContext.RequestAborted);

			return users.Map();
		}

		/// <summary>
		/// Add Institute to User entity
		/// </summary>
		/// <param name="id"></param>
		/// <param name="request"></param>
		/// <response code="201" >Entity created</response>
		/// <response code="400">Entity has missing/invalid values</response>
		[HttpPut("/user/{userId:required}/institute/{instituteId:required}/")]
		public async Task<ActionResult<InstituteUserViewModel>> AddInstituteToUserAsync([FromRoute] string userId, [FromBody] string instituteId)
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
		public async Task<ActionResult> RemoveInstituteFromUserAsync([FromRoute] string userId, [FromRoute] string instituteId)
		{
			var command = new DeleteInstituteUserCommand(userId, instituteId);

			await _mediator.Send(command);

			return NoContent();
		}
	}
}
