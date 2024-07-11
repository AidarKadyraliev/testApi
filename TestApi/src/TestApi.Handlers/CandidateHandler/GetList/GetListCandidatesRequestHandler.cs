using MediatR;
using TestApi.Domain;
using TestApi.Handlers.Services;

namespace TestApi.Handlers.CandidateHandler.GetList;
public class GetListCandidatesRequestHandler : IRequestHandler<GetListOfCandidatesRequest, IEnumerable<Candidate>>
{
	private readonly ICandidateService _service;

	public GetListCandidatesRequestHandler(ICandidateService service)
	{
		_service = service;
	}

	public async Task<IEnumerable<Candidate>> Handle(GetListOfCandidatesRequest request, CancellationToken cancellationToken)
	{
		return await _service.GetCandidatesAsync(cancellationToken);
	}
}
