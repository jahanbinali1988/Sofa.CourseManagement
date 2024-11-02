using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sofa.CourseManagement.RestApi.Models;
using Sofa.CourseManagement.RestApi.Models.Posts;
using Sofa.CourseManagement.Application.Contract.Posts.Commands;
using Sofa.CourseManagement.Application.Contract.Posts.Dtos;
using Sofa.CourseManagement.Application.Contract.Posts.Queries;

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
		[HttpPost("/institute/{instituteId:required}/field/{fieldId:required}/course/{courseId:required}/term/{termId:required}/session/{sessionId:required}/lessonplan/{lessonplanId:required}/post")]
		public async Task<ActionResult<PostBaseViewModel>> CreateAsync([FromQuery] Guid instituteId, [FromQuery] Guid fieldId,
			[FromQuery] Guid courseId, [FromQuery] Guid termId, [FromQuery] Guid sessionId, [FromQuery] Guid lessonplanId, [FromBody] CreatePostViewModel request)
		{
			var command = request.ToCommand(instituteId, fieldId, courseId, termId, sessionId, lessonplanId);

			var post = await _mediator.Send(command);

			return Created(PostBaseViewModel.Create(post));
		}

		/// <summary>
		/// Get Post by Id
		/// </summary>
		/// <param name="id"></param>
		/// <response code="200">Successfully get entity</response>
		/// <response code="400">Entity has missing/invalid values</response>
		/// <response code="404">Entity not found</response>
		[HttpGet("/institute/{instituteId:required}/field/{fieldId:required}/course/{courseId:required}/term/{termId:required}/session/{sessionId:required}/lessonplan/{lessonplanId:required}/post/{postId:required}")]
		public async Task<ActionResult<PostBaseViewModel>> GetPostByIdAsync([FromQuery] Guid instituteId, [FromQuery] Guid fieldId,
			[FromQuery] Guid courseId, [FromQuery] Guid termId, [FromQuery] Guid sessionId, [FromQuery] Guid lessonplanId, [FromQuery] Guid postId)
		{
			var query = new GetPostByIdQuery(instituteId, fieldId, courseId, termId, sessionId, lessonplanId, postId);

			var post = await _mediator.Send(query, HttpContext.RequestAborted);

			return Get<PostBaseViewModel>(PostBaseViewModel.Create(post));
		}

		/// <summary>
		/// Get Posts list
		/// </summary>
		/// <param name="request"></param>
		/// <response code="200">Successfully get entities</response>
		/// <response code="400">Entity has missing/invalid values</response>
		/// <response code="404">Entity not found</response>
		[HttpGet("/institute/{instituteId:required}/field/{fieldId:required}/course/{courseId:required}/term/{termId:required}/session/{sessionId:required}/lessonplan/{lessonplanId:required}/post/")]
		public async Task<ActionResult<IEnumerable<PostBaseViewModel>>> GetPostListAsync([FromQuery] Guid instituteId, [FromQuery] Guid fieldId,
			[FromQuery] Guid courseId, [FromQuery] Guid termId, [FromQuery] Guid sessionId, [FromQuery] Guid lessonplanId, [FromQuery] GetListRequest request)
		{
			var query = new GetAllPostsQuery(instituteId, fieldId, courseId, termId, sessionId, lessonplanId, request.Offset, request.Count, request.Keyword);

			var posts = await _mediator.Send(query, HttpContext.RequestAborted);
			
			return List<PostBaseDto, PostBaseViewModel>(posts);
		}

		/// <summary>
		/// Update Post entity
		/// </summary>
		/// <param name="id"></param>
		/// <param name="request"></param>
		/// <response code="201" >Entity created</response>
		/// <response code="400">Entity has missing/invalid values</response>
		[HttpPut("/institute/{instituteId:required}/field/{fieldId:required}/course/{courseId:required}/term/{termId:required}/session/{sessionId:required}/lessonplan/{lessonplanId:required}/post/{postId:required}")]
		public async Task<ActionResult<PostBaseViewModel>> UpdateAsync([FromQuery] Guid instituteId, [FromQuery] Guid fieldId,
			[FromQuery] Guid courseId, [FromQuery] Guid termId, [FromQuery] Guid sessionId, [FromQuery] Guid lessonplanId, [FromQuery] Guid postId,
			[FromBody] CreatePostViewModel request)
		{
			var command = request.ToCommand(instituteId, fieldId, courseId, termId, sessionId, lessonplanId, postId);

			var post = await _mediator.Send(command);

			return Ok();
		}

		/// <summary>
		/// Create Post entity
		/// </summary>
		/// <param name="id"></param>
		/// <response code="201" >Entity created</response>
		/// <response code="400">Entity has missing/invalid values</response>
		[HttpDelete("/institute/{instituteId:required}/field/{fieldId:required}/course/{courseId:required}/term/{termId:required}/session/{sessionId:required}/lessonplan/{lessonplanId:required}/post/{postId:required}")]
		public async Task<ActionResult> DeleteAsync([FromQuery] Guid instituteId, [FromQuery] Guid fieldId,
			[FromQuery] Guid courseId, [FromQuery] Guid termId, [FromQuery] Guid sessionId, [FromQuery] Guid lessonplanId, [FromQuery] Guid postId)
		{
			var command = new DeletePostCommand(instituteId, fieldId, courseId, termId, sessionId, lessonplanId, postId);
			var post = await _mediator.Send(command);

			return NoContent();
		}
	}
}
