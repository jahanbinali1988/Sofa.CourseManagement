using Microsoft.AspNetCore.Mvc;
using Sofa.CourseManagement.RestApi.Models;
using Sofa.CourseManagement.RestApi.Models.Posts;
using Sofa.CourseManagement.Application.Contract.Posts.Commands;
using Sofa.CourseManagement.Application.Contract.Posts.Queries;
using Sofa.CourseManagement.SharedKernel.Application;

namespace Sofa.CourseManagement.RestApi.Controllers
{
	public partial class InstituteController
	{
		/// <summary>s
		/// Create Post entity
		/// </summary>
		/// <param name="request"></param>
		/// <response code="201" >Entity created</response>
		/// <response code="400">Entity has missing/invalid values</response>
		[HttpPost("/institute/{instituteId:required}/field/{fieldId:required}/course/{courseId:required}/session/{sessionId:required}/lessonplan/{lessonplanId:required}/post")]
		public async Task<ActionResult<PostBaseViewModel>> CreateAsync([FromQuery] string instituteId, [FromQuery] string fieldId,
			[FromQuery] string courseId, [FromQuery] string sessionId, [FromQuery] string lessonplanId, [FromBody] CreatePostViewModel request)
		{
			var command = request.ToCommand(instituteId, fieldId, courseId, sessionId, lessonplanId);

			var post = await _mediator.Send(command);

			return PostBaseViewModel.Create(post);
		}

		/// <summary>
		/// Get Post by Id
		/// </summary>
		/// <param name="id"></param>
		/// <response code="200">Successfully get entity</response>
		/// <response code="400">Entity has missing/invalid values</response>
		/// <response code="404">Entity not found</response>
		[HttpGet("/institute/{instituteId:required}/field/{fieldId:required}/course/{courseId:required}/session/{sessionId:required}/lessonplan/{lessonplanId:required}/post/{postId:required}")]
		public async Task<ActionResult<PostBaseViewModel>> GetPostByIdAsync([FromQuery] string instituteId, [FromQuery] string fieldId,
			[FromQuery] string courseId, [FromQuery] string sessionId, [FromQuery] string lessonplanId, [FromQuery] string postId)
		{
			var query = new GetPostByIdQuery(instituteId, fieldId, courseId, sessionId, lessonplanId, postId);

			var post = await _mediator.Send(query, HttpContext.RequestAborted);

			return PostBaseViewModel.Create(post);
		}

		/// <summary>
		/// Get Posts list
		/// </summary>
		/// <param name="request"></param>
		/// <response code="200">Successfully get entities</response>
		/// <response code="400">Entity has missing/invalid values</response>
		/// <response code="404">Entity not found</response>
		[HttpGet("/institute/{instituteId:required}/field/{fieldId:required}/course/{courseId:required}/session/{sessionId:required}/lessonplan/{lessonplanId:required}/post/")]
		public async Task<ActionResult<Pagination<PostBaseViewModel>>> GetPostListAsync([FromQuery] string instituteId, [FromQuery] string fieldId,
			[FromQuery] string courseId, [FromQuery] string sessionId, [FromQuery] string lessonplanId, [FromQuery] GetListRequest request)
		{
			var query = new GetAllPostsQuery(instituteId, fieldId, courseId, sessionId, lessonplanId, request.Offset, request.Count, request.Keyword);

			var posts = await _mediator.Send(query, HttpContext.RequestAborted);
			
			return posts.Map();
		}

		/// <summary>
		/// Update Post entity
		/// </summary>
		/// <param name="id"></param>
		/// <param name="request"></param>
		/// <response code="201" >Entity created</response>
		/// <response code="400">Entity has missing/invalid values</response>
		[HttpPut("/institute/{instituteId:required}/field/{fieldId:required}/course/{courseId:required}/session/{sessionId:required}/lessonplan/{lessonplanId:required}/post/{postId:required}")]
		public async Task<ActionResult<PostBaseViewModel>> UpdateAsync([FromQuery] string instituteId, [FromQuery] string fieldId,
			[FromQuery] string courseId, [FromQuery] string sessionId, [FromQuery] string lessonplanId, [FromQuery] string postId,
			[FromBody] CreatePostViewModel request)
		{
			var command = request.ToCommand(instituteId, fieldId, courseId, sessionId, lessonplanId, postId);

			var post = await _mediator.Send(command);

			return Ok();
		}

		/// <summary>
		/// Delete Post entity
		/// </summary>
		/// <param name="id"></param>
		/// <response code="201" >Entity created</response>
		/// <response code="400">Entity has missing/invalid values</response>
		[HttpDelete("/institute/{instituteId:required}/field/{fieldId:required}/course/{courseId:required}/session/{sessionId:required}/lessonplan/{lessonplanId:required}/post/{postId:required}")]
		public async Task<ActionResult> DeletePostAsync([FromQuery] string instituteId, [FromQuery] string fieldId,
			[FromQuery] string courseId, [FromQuery] string sessionId, [FromQuery] string lessonplanId, [FromQuery] string postId)
		{
			var command = new DeletePostCommand(instituteId, fieldId, courseId, sessionId, lessonplanId, postId);
			
			await _mediator.Send(command);

			return NoContent();
		}
	}
}
