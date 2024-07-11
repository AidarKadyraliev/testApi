using TestApi.DataContracts.Dto;
using TestApi.Domain;
using TestApi.Repositories.UnitOfWork;
using TestApi.Repositories.UnitOfWork.Repositories;

namespace TestApi.Handlers.Services;
public class CandidateService : ICandidateService
{
	private readonly ICandidateRepository _repository;

	public CandidateService(IUnitOfWork unitOfWork)
	{
		_repository = unitOfWork.CandidateRepository;
	}

	public async Task<Candidate> CreateAsync(CandidateDto candidateDto)
	{
		var candidate = new Candidate()
		{
			Id = Guid.NewGuid(),
			Name = candidateDto.FirstName,
			LastName = candidateDto.LastName,
			PhoneNumber = candidateDto.PhoneNumber,
			StartTime = candidateDto.StartDate,
			EndTime = candidateDto.EndDate,
			Comment = candidateDto.FreeText,
			Email = candidateDto.Email,
			GithubUrl =	candidateDto.GitHublUrl,
			LinkedinUrl = candidateDto.LinkedInUrl
		};
		return await _repository.CreateAsync(candidate);
	}

	public async Task DeleteAsync(Guid candidateId)
	{
		await _repository.DeleteAsync(candidateId);
	}

	public Task<Candidate> GetCandidateAsync(Guid candidateId)
	{
		return _repository.GetCandidateAsync(candidateId);
	}

	public async Task<IEnumerable<Candidate>> GetCandidatesAsync(CancellationToken cancellationToken)
	{
		return await _repository.GetCandidatesAsync(cancellationToken);
	}

	public Task<Candidate> UpdateAsync(Guid candidateId, CandidateDto candidateDto)
	{
		return _repository.UpdateAsync(candidateId, candidateDto);
	}
}
