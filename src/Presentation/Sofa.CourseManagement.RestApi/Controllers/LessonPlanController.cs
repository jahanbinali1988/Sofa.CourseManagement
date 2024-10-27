using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sofa.CourseManagement.RestApi.Models;
using Sofa.CourseManagement.RestApi.Models.LessonPlans;
using Sofa.CourseManagement.Application.Contract.LessonPlans.Commands;
using Sofa.CourseManagement.Application.Contract.LessonPlans.Dtos;
using Sofa.CourseManagement.Application.Contract.LessonPlans.Queries;

namespace Sofa.CourseManagement.RestApi.Controllers
{
	[ApiController]
	[Route("lessonplan")]
	public partial class LessonPlanController : BaseController
	{
		private readonly ILogger<LessonPlanController> _logger;

		private readonly IMediator _mediator;
		public LessonPlanController(IMediator mediator, ILogger<LessonPlanController> logger) : base(logger)
		{
			_mediator = mediator;
			_logger = logger;
		}

		/// <summary>
		/// Create LessonPlan entity
		/// </summary>
		/// <param name="request"></param>
		/// <response code="201" >Entity created</response>
		/// <response code="400">Entity has missing/invalid values</response>
		[HttpPost]
		public async Task<ActionResult<LessonPlanViewModel>> CreateAsync([FromBody] CreateLessonPlanViewModel request)
		{
			var command = request.ToCommand();

			var lessonPlan = await _mediator.Send(command);

			return Created(LessonPlanViewModel.Create(lessonPlan));
		}

		/// <summary>
		/// Get LessonPlan by Id
		/// </summary>
		/// <param name="id"></param>
		/// <response code="200">Successfully get entity</response>
		/// <response code="400">Entity has missing/invalid values</response>
		/// <response code="404">Entity not found</response>
		[HttpGet("{id:required}")]
		public async Task<ActionResult<LessonPlanViewModel>> GetLessonPlanByIdAsync([FromQuery] Guid id)
		{
			var query = new GetLessonPlanByIdQuery(id);

			var lessonPlan = await _mediator.Send(query, HttpContext.RequestAborted);

			return Get<LessonPlanViewModel>(LessonPlanViewModel.Create(lessonPlan));
		}

		/// <summary>
		/// Get LessonPlans list
		/// </summary>
		/// <param name="request"></param>
		/// <response code="200">Successfully get entities</response>
		/// <response code="400">Entity has missing/invalid values</response>
		/// <response code="404">Entity not found</response>
		[HttpGet]
		public async Task<ActionResult<IEnumerable<LessonPlanViewModel>>> GetLessonPlanListAsync([FromQuery] GetListRequest request)
		{
			var query = new GetAllLessonPlansQuery(request.Offset, request.Count, request.Keyword);

			var lessonPlans = await _mediator.Send(query, HttpContext.RequestAborted);

			return List<LessonPlanDto, LessonPlanViewModel>(lessonPlans);
		}

		/// <summary>
		/// Create LessonPlan entity
		/// </summary>
		/// <param name="id"></param>
		/// <param name="request"></param>
		/// <response code="201" >Entity created</response>
		/// <response code="400">Entity has missing/invalid values</response>
		[HttpPut("{id:required}")]
		public async Task<ActionResult<LessonPlanViewModel>> UpdateAsync([FromQuery] Guid id, [FromBody] CreateLessonPlanViewModel request)
		{
			var command = request.ToCommand(id);

			var lessonPlan = await _mediator.Send(command);

			return Ok();
		}

		/// <summary>
		/// Create LessonPlan entity
		/// </summary>
		/// <param name="id"></param>
		/// <response code="201" >Entity created</response>
		/// <response code="400">Entity has missing/invalid values</response>
		[HttpDelete("{id:required}")]
		public async Task<ActionResult> DeleteAsync([FromQuery] Guid id)
		{
			var command = new DeleteLessonPlanCommand(id);
			var lessonPlan = await _mediator.Send(command);

			return NoContent();
		}
	}
}
