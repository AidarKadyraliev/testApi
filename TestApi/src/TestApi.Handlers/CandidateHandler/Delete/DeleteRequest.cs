using MediatR;

namespace TestApi.Handlers.CandidateHandler.Delete;
public class DeleteRequest : IRequest
{
	public Guid CandidateId { get; set; }

	public DeleteRequest(Guid candidateId)
	{
		CandidateId = candidateId;
	}
}
