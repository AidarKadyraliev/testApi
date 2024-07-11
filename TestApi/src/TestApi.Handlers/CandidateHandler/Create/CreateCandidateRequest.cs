using MediatR;
using TestApi.DataContracts.Dto;
using TestApi.Domain;

namespace TestApi.Handlers.CandidateHandler.Create;
public class CreateCandidateRequest : IRequest<Candidate>
{
	public CandidateDto Dto { get; set; }

	public CreateCandidateRequest(CandidateDto dto)
	{
		Dto = dto;
	}
}
