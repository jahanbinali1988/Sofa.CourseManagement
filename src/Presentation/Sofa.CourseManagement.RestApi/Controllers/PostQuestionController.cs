using Microsoft.AspNetCore.Mvc;
using Sofa.CourseManagement.Application.Contract.PostQuestions.Commands;
using Sofa.CourseManagement.Application.Contract.PostQuestions.Queries;
using Sofa.CourseManagement.RestApi.Models.Posts;

namespace Sofa.CourseManagement.RestApi.Controllers
{
	public partial class InstituteController
	{
		/// <summary>s
		/// Create Post Question entity
		/// </summary>
		/// <param name="request"></param>
		/// <response code="201" >Entity created</response>
		/// <response code="400">Entity has missing/invalid values</response>
		[HttpPost("/institute/{instituteId:required}/field/{fieldId:required}/course/{courseId:required}/session/{sessionId:required}/lessonplan/{lessonplanId:required}/post/{postId:required}/question")]
		public async Task<ActionResult<PostQuestionViewModel>> CreatePostQuestionAsync([FromRoute] string instituteId, [FromRoute] string fieldId,
			[FromRoute] string courseId, [FromRoute] string sessionId, [FromRoute] string lessonplanId, [FromRoute] string postId, [FromBody] CreatePostQuestionViewModel request)
		{
			var command = request.ToCommand(instituteId, fieldId, courseId, sessionId, lessonplanId, postId);

			var postQuestion = await _mediator.Send(command);

			return PostQuestionViewModel.Create(postQuestion);
		}

		/// <summary>
		/// Get Post Question by Id
		/// </summary>
		/// <param name="id"></param>
		/// <response code="200">Successfully get entity</response>
		/// <response code="400">Entity has missing/invalid values</response>
		/// <response code="404">Entity not found</response>
		[HttpGet("/institute/{instituteId:required}/field/{fieldId:required}/course/{courseId:required}/session/{sessionId:required}/lessonplan/{lessonplanId:required}/post/{postId:required}/question/{questionId:required}")]
		public async Task<ActionResult<PostQuestionViewModel>> GetPostQuestionByIdAsync([FromRoute] string instituteId, [FromRoute] string fieldId,
			[FromRoute] string courseId, [FromRoute] string sessionId, [FromRoute] string lessonplanId, [FromRoute] string postId, [FromRoute] string questionId)
		{
			var query = new GetPostQuestionByIdQuery(instituteId, fieldId, courseId, sessionId, lessonplanId, postId, questionId);

			var postQuestion = await _mediator.Send(query, HttpContext.RequestAborted);

			return PostQuestionViewModel.Create(postQuestion);
		}

		/// <summary>
		/// Create Post Question entity
		/// </summary>
		/// <param name="id"></param>
		/// <response code="201" >Entity created</response>
		/// <response code="400">Entity has missing/invalid values</response>
		[HttpDelete("/institute/{instituteId:required}/field/{fieldId:required}/course/{courseId:required}/session/{sessionId:required}/lessonplan/{lessonplanId:required}/post/{postId:required}/question/{questionId:required}")]
		public async Task<ActionResult> DeleteAsync([FromRoute] string instituteId, [FromRoute] string fieldId,
			[FromRoute] string courseId, [FromRoute] string sessionId, [FromRoute] string lessonplanId, [FromRoute] string postId, [FromRoute] string questionId)
		{
			var command = new DeletePostQuestionCommand(instituteId, fieldId, courseId, sessionId, lessonplanId, postId, questionId);
			
			await _mediator.Send(command);

			return NoContent();
		}
	}
}
