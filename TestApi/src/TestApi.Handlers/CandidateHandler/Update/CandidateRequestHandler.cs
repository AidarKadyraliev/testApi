using MediatR;
using TestApi.Domain;
using TestApi.Handlers.Services;

namespace TestApi.Handlers.CandidateHandler.Update;
public class CandidateRequestHandler : IRequestHandler<UpdateRequest, Candidate>
{
	private readonly ICandidateService _service;

	public CandidateRequestHandler(ICandidateService service)
	{
		_service = service;
	}

	public async Task<Candidate> Handle(UpdateRequest request, CancellationToken cancellationToken)
	{
		return await _service.UpdateAsync(request.CandidateId, request.Dto);
	}
}
