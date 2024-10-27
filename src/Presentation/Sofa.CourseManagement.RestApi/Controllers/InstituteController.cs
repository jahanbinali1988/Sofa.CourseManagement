using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sofa.CourseManagement.RestApi.Models;
using Sofa.CourseManagement.RestApi.Models.Institutes;
using Sofa.CourseManagement.Application.Contract.Institutes.Commands;
using Sofa.CourseManagement.Application.Contract.Institutes.Dtos;
using Sofa.CourseManagement.Application.Contract.Institutes.Queries;
using Microsoft.AspNetCore.Authorization;

namespace Sofa.CourseManagement.RestApi.Controllers
{
	[ApiController]
    [Route("institute")]
    public partial class InstituteController : BaseController
    {
        private readonly ILogger<InstituteController> _logger;

        private readonly IMediator _mediator;
        public InstituteController(IMediator mediator, ILogger<InstituteController> logger) : base(logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

		/// <summary>
		/// Create Institute entity
		/// </summary>
		/// <param name="request"></param>
		/// <response code="201" >Entity created</response>
		/// <response code="400">Entity has missing/invalid values</response>
		[Authorize]		
		[HttpPost]
        public async Task<ActionResult<InstituteViewModel>> CreateInstituteAsync([FromBody] CreateInstituteViewModel request)
        {
            var command = request.ToCommand();

            var institute = await _mediator.Send(command);

            return Created(InstituteViewModel.Create(institute));
        }

		/// <summary>
		/// Get Institute by Id
		/// </summary>
		/// <param name="id"></param>
		/// <response code="200">Successfully get entity</response>
		/// <response code="400">Entity has missing/invalid values</response>
		/// <response code="404">Entity not found</response>
		[HttpGet("{id:required}")]
		public async Task<ActionResult<InstituteViewModel>> GetInstituteByIdAsync([FromQuery] Guid id)
		{
			var query = new GetInstituteByIdQuery(id);

			var institute = await _mediator.Send(query, HttpContext.RequestAborted);

			return Get<InstituteViewModel>(InstituteViewModel.Create(institute));
		}

		/// <summary>
		/// Get Institutes list
		/// </summary>
		/// <param name="request"></param>
		/// <response code="200">Successfully get entities</response>
		/// <response code="400">Entity has missing/invalid values</response>
		/// <response code="404">Entity not found</response>
		[HttpGet]
        public async Task<ActionResult<IEnumerable<InstituteViewModel>>> GetInstituteListAsync([FromQuery] GetListRequest request)
        {
            var query = new GetAllInstitutesQuery(request.Keyword, request.Offset, request.Count);

            var institutes = await _mediator.Send(query, HttpContext.RequestAborted);

            return List<InstituteDto, InstituteViewModel>(institutes);
        }

		/// <summary>
		/// Create Institute entity
		/// </summary>
		/// <param name="id"></param>
		/// <param name="request"></param>
		/// <response code="201" >Entity created</response>
		/// <response code="400">Entity has missing/invalid values</response>
		[HttpPut("{id:required}")]
		public async Task<ActionResult<InstituteViewModel>> UpdateInstituteAsync([FromQuery] Guid id, [FromBody] CreateInstituteViewModel request)
		{
			var command = request.ToCommand(id);

			var institute = await _mediator.Send(command);

			return Ok();
		}

		/// <summary>
		/// Create Institute entity
		/// </summary>
		/// <param name="id"></param>
		/// <param name="request"></param>
		/// <response code="201" >Entity created</response>
		/// <response code="400">Entity has missing/invalid values</response>
		[HttpPut("{id:required}/address")]
		public async Task<ActionResult> UpdateInstituteAddressAsync([FromQuery] Guid id, [FromBody] UpsertInstituteAddressViewModel request)
		{
			var command = request.ToCommand(id);

			await _mediator.Send(command);

			return Ok();
		}

		/// <summary>
		/// Create Institute entity
		/// </summary>
		/// <param name="id"></param>
		/// <response code="201" >Entity created</response>
		/// <response code="400">Entity has missing/invalid values</response>
		[HttpDelete("{id:required}")]
		public async Task<ActionResult> DeleteInstituteAsync([FromQuery] Guid id)
		{
			var command = new DeleteInstituteCommand(id);
			
			await _mediator.Send(command);

			return NoContent();
		}
	}
}
