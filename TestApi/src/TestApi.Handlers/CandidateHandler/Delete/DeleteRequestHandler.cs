using MediatR;
using TestApi.Handlers.Services;

namespace TestApi.Handlers.CandidateHandler.Delete;
public class DeleteRequestHandler : IRequestHandler<DeleteRequest>
{
	private readonly ICandidateService _service;

	public DeleteRequestHandler(ICandidateService service)
	{
		_service = service;
	}

	public async Task Handle(DeleteRequest request, CancellationToken cancellationToken)
	{
		await _service.DeleteAsync(request.CandidateId);
	}
}
