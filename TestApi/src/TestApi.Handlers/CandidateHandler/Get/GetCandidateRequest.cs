using MediatR;
using TestApi.Domain;

namespace TestApi.Handlers.CandidateHandler.Get;
public class GetCandidateRequest : IRequest<Candidate>
{
	public Guid Id { get; set; }

	public GetCandidateRequest(Guid id)
	{
		Id = id;
	}
}
