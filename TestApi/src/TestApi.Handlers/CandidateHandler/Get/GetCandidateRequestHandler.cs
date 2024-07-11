using MediatR;
using TestApi.Domain;
using TestApi.Handlers.Services;

namespace TestApi.Handlers.CandidateHandler.Get;
public class GetCandidateRequestHandler : IRequestHandler<GetCandidateRequest, Candidate>
{
	private readonly ICandidateService _service;
	public GetCandidateRequestHandler(ICandidateService service)
	{
		_service = service;
	}

	public async Task<Candidate> Handle(GetCandidateRequest request, CancellationToken cancellationToken)
	{
		return await _service.GetCandidateAsync(request.Id);
	}
}
