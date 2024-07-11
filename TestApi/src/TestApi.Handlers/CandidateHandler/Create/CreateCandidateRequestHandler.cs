using MediatR;
using TestApi.Domain;
using TestApi.Handlers.Services;


namespace TestApi.Handlers.CandidateHandler.Create;
public class CreateCandidateRequestHandler : IRequestHandler<CreateCandidateRequest, Candidate>
{
	private readonly ICandidateService _service;

	public CreateCandidateRequestHandler(ICandidateService service)
	{
		_service = service;
	}

	public async Task<Candidate> Handle(CreateCandidateRequest request, CancellationToken cancellationToken)
	{
		var result = await _service.CreateAsync(request.Dto);
		return result;
	}
}
