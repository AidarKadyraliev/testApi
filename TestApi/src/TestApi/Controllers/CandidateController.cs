using MediatR;
using Microsoft.AspNetCore.Mvc;
using TestApi.DataContracts.Dto;
using TestApi.Handlers.CandidateHandler.Create;
using TestApi.Handlers.CandidateHandler.Delete;
using TestApi.Handlers.CandidateHandler.Get;
using TestApi.Handlers.CandidateHandler.GetList;
using TestApi.Handlers.CandidateHandler.Update;

namespace TestApi.Controllers;

[ApiController]
public class CandidateController : ControllerBase
{
	private readonly IMediator _mediator;

	public CandidateController(IMediator mediator)
	{
		_mediator = mediator;
	}

	[HttpPost("candidate")]
	public async Task<IActionResult> Create([FromBody] CandidateDto createDto)
	{
		return Ok(await _mediator.Send(new CreateCandidateRequest(createDto)));
	}

	[HttpPut("candidate")]
	public async Task<IActionResult> Update([FromQuery] Guid candidateId, [FromBody] CandidateDto dto)
	{
		return Ok(await _mediator.Send(new UpdateRequest(candidateId, dto)));
	}

	[HttpDelete("candidate")]
	public async Task<IActionResult> Delete([FromQuery] Guid candidateId)
	{
		await _mediator.Send(new DeleteRequest(candidateId));
		return Ok();
	}
	[HttpGet("all")]
	public async Task<IActionResult> GetAll()
	{
		return Ok(await _mediator.Send(new GetListOfCandidatesRequest()));
	}

	[HttpGet("id")]
	public async Task<IActionResult> GetOne([FromQuery] Guid candidateId)
	{
		return Ok(await _mediator.Send(new GetCandidateRequest(candidateId)));
	}

}
