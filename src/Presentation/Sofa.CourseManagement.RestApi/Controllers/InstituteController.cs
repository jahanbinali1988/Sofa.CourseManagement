using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sofa.CourseManagement.RestApi.Models;
using Sofa.CourseManagement.RestApi.Models.Institutes;
using Sofa.CourseManagement.Application.Contract.Institutes.Commands;
using Sofa.CourseManagement.Application.Contract.Institutes.Dtos;
using Sofa.CourseManagement.Application.Contract.Institutes.Queries;
using Microsoft.AspNetCore.Authorization;
using Sofa.CourseManagement.Application.Contract.InstituteUsers.Commands;
using Sofa.CourseManagement.Application.Contract.InstituteUsers.Dtos;
using Sofa.CourseManagement.Application.Contract.InstituteUsers.Queries;
using Sofa.CourseManagement.RestApi.Models.InstituteUsers;
using Sofa.CourseManagement.SharedKernel.Application;

namespace Sofa.CourseManagement.RestApi.Controllers
{
	[ApiController]
    [Route("/institute")]
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
		//[Authorize(Policy = AuthorizationPolicies.AdminPolicy)]
		[HttpPost]
        public async Task<ActionResult<InstituteViewModel>> CreateInstituteAsync([FromBody] CreateInstituteViewModel request)
        {
            var command = request.ToCommand();

            var institute = await _mediator.Send(command);

            return InstituteViewModel.Create(institute);
        }

		/// <summary>
		/// Get Institute by Id
		/// </summary>
		/// <param name="id"></param>
		/// <response code="200">Successfully get entity</response>
		/// <response code="400">Entity has missing/invalid values</response>
		/// <response code="404">Entity not found</response>
		[HttpGet("{id:required}")]
		public async Task<ActionResult<InstituteViewModel>> GetInstituteByIdAsync([FromRoute] string id)
		{
			var query = new GetInstituteByIdQuery(id);

			var institute = await _mediator.Send(query, HttpContext.RequestAborted);

			return InstituteViewModel.Create(institute);
		}

		/// <summary>
		/// Get Institutes list
		/// </summary>
		/// <param name="request"></param>
		/// <response code="200">Successfully get entities</response>
		/// <response code="400">Entity has missing/invalid values</response>
		/// <response code="404">Entity not found</response>
		[HttpGet]
        public async Task<ActionResult<Pagination<InstituteViewModel>>> GetInstituteListAsync([FromQuery] GetListRequest request)
        {
            var query = new GetAllInstitutesQuery(request.Keyword, request.Offset, request.Count);

            var institutes = await _mediator.Send(query, HttpContext.RequestAborted);

            return  institutes.Map();
        }

		/// <summary>
		/// Create Institute entity
		/// </summary>
		/// <param name="id"></param>
		/// <param name="request"></param>
		/// <response code="201" >Entity created</response>
		/// <response code="400">Entity has missing/invalid values</response>
		[HttpPut("{id:required}")]
		public async Task<ActionResult<InstituteViewModel>> UpdateInstituteAsync([FromRoute] string id, [FromBody] CreateInstituteViewModel request)
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
		public async Task<ActionResult> UpdateInstituteAddressAsync([FromRoute] string id, [FromBody] UpsertInstituteAddressViewModel request)
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
		public async Task<ActionResult> DeleteInstituteAsync([FromRoute] string id)
		{
			var command = new DeleteInstituteCommand(id);
			
			await _mediator.Send(command);

			return NoContent();
		}
	}
}
