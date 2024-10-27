using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sofa.CourseManagement.RestApi.Models;
using Sofa.CourseManagement.RestApi.Models.Posts;
using Sofa.CourseManagement.Application.Contract.Posts.Commands;
using Sofa.CourseManagement.Application.Contract.Posts.Dtos;
using Sofa.CourseManagement.Application.Contract.Posts.Queries;

namespace Sofa.CourseManagement.RestApi.Controllers
{
	public partial class LessonPlanController
	{
		/// <summary>s
		/// Create Post entity
		/// </summary>
		/// <param name="request"></param>
		/// <response code="201" >Entity created</response>
		/// <response code="400">Entity has missing/invalid values</response>
		[HttpPost("{lessonpalnId:required}/post")]
		public async Task<ActionResult<PostBaseViewModel>> CreateAsync([FromQuery]Guid lessonpalnId, [FromBody] CreatePostViewModel request)
		{
			var command = request.ToCommand(lessonpalnId);

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
		[HttpGet("{lessonpalnId:required}/post/{postId:required}")]
		public async Task<ActionResult<PostBaseViewModel>> GetPostByIdAsync([FromQuery] Guid lessonpalnId, [FromQuery] Guid postId)
		{
			var query = new GetPostByIdQuery(lessonpalnId, postId);

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
		[HttpGet("{lessonpalnId:required}/post")]
		public async Task<ActionResult<IEnumerable<PostBaseViewModel>>> GetPostListAsync([FromQuery] Guid lessonpalnId, [FromQuery] GetListRequest request)
		{
			var query = new GetAllPostsQuery(lessonpalnId, request.Offset, request.Count, request.Keyword);

			var posts = await _mediator.Send(query, HttpContext.RequestAborted);
			
			return List<PostBaseDto, PostBaseViewModel>(posts);
		}

		/// <summary>
		/// Create Post entity
		/// </summary>
		/// <param name="id"></param>
		/// <param name="request"></param>
		/// <response code="201" >Entity created</response>
		/// <response code="400">Entity has missing/invalid values</response>
		[HttpPut("{lessonpalnId:required}/post/{postId:required}")]
		public async Task<ActionResult<PostBaseViewModel>> UpdateAsync([FromQuery] Guid lessonpalnId, [FromQuery] Guid postId, [FromBody] CreatePostViewModel request)
		{
			var command = request.ToCommand(lessonpalnId, postId);

			var post = await _mediator.Send(command);

			return Ok();
		}

		/// <summary>
		/// Create Post entity
		/// </summary>
		/// <param name="id"></param>
		/// <response code="201" >Entity created</response>
		/// <response code="400">Entity has missing/invalid values</response>
		[HttpDelete("{lessonpalnId:required}/post/{postId:required}")]
		public async Task<ActionResult> DeleteAsync([FromQuery] Guid lessonpalnId, [FromQuery] Guid postId)
		{
			var command = new DeletePostCommand(lessonpalnId, postId);
			var post = await _mediator.Send(command);

			return NoContent();
		}
	}
}
