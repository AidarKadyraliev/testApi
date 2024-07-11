using TestApi.DataContracts.Dto;
using TestApi.Domain;

namespace TestApi.Handlers.Services;
public interface ICandidateService
{
	/// <summary>
	///		Get candidate by Id
	/// </summary>
	/// <param name="candidateId"></param>
	/// <returns></returns>
	Task<Candidate> GetCandidateAsync(Guid candidateId);

	/// <summary>
	///		Get candidates list
	/// </summary>
	/// <returns></returns>
	Task<IEnumerable<Candidate>> GetCandidatesAsync(CancellationToken cancellationToken);

	/// <summary>
	///		Create candidate
	/// </summary>
	/// <param name="candidateDto"></param>
	/// <returns></returns>
	Task<Candidate> CreateAsync(CandidateDto candidateDto);

	/// <summary>
	///		Update candidate
	/// </summary>
	/// <param name="candidateDto"></param>
	/// <returns></returns>
	Task<Candidate> UpdateAsync(Guid candidateId, CandidateDto candidateDto);

	/// <summary>
	///		Delete candidate
	/// </summary>
	/// <param name="candidateId"></param>
	/// <returns></returns>
	Task DeleteAsync(Guid candidateId);
}
