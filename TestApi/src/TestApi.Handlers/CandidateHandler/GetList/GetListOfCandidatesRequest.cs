using MediatR;
using TestApi.Domain;

namespace TestApi.Handlers.CandidateHandler.GetList;
public class GetListOfCandidatesRequest : IRequest<IEnumerable<Candidate>>{}
