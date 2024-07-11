using MediatR;
using TestApi.DataContracts.Dto;
using TestApi.Domain;

namespace TestApi.Handlers.CandidateHandler.Update;
public class UpdateRequest : IRequest<Candidate>
{
	public Guid CandidateId {  get; set; }
	public CandidateDto Dto { get; set; }

	public UpdateRequest(Guid candidateId, CandidateDto dto)
	{
		CandidateId = candidateId;
		Dto = dto;
	}
}
