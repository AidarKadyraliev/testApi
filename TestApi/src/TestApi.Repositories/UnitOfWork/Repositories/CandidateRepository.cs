using Microsoft.EntityFrameworkCore;
using TestApi.DataContracts.Dto;
using TestApi.Domain;

namespace TestApi.Repositories.UnitOfWork.Repositories;
public class CandidateRepository : ICandidateRepository
{
	private readonly CandidatesDbContext _context;

	public CandidateRepository(CandidatesDbContext context)
	{
		_context = context;
	}

	public async Task<Candidate> CreateAsync(Candidate candidate)
	{
		await _context.Candidates.AddAsync(candidate);
		await _context.SaveChangesAsync();
		return candidate;
	}

	public async Task<int> DeleteAsync(Guid candidateId)
	{
		var candidate = await _context.Candidates.FirstOrDefaultAsync(x => x.Id == candidateId) 
			?? throw new NullReferenceException(nameof(Candidate));

		_context.Candidates.Remove(candidate);
		return await _context.SaveChangesAsync();
	}

	public async Task<Candidate> GetCandidateAsync(Guid candidateId)
	{
		var candidate = await _context.Candidates.AsNoTracking().FirstOrDefaultAsync(x => x.Id == candidateId)
			?? throw new NullReferenceException(nameof(Candidate));

		return candidate;
	}

	public async Task<IEnumerable<Candidate>> GetCandidatesAsync(CancellationToken cancellationToken)
	{
		var candidates = await _context.Candidates.AsNoTracking().ToListAsync(cancellationToken);
		return candidates;
	}

	public async Task<Candidate> UpdateAsync(Guid candidateId, CandidateDto candidateDto)
	{
		var candidate = await _context.Candidates.FirstOrDefaultAsync(x => x.Id == candidateId) ??
			throw new NullReferenceException(nameof(Candidate));

		candidate.Email = candidateDto.Email;
		candidate.PhoneNumber = candidateDto.PhoneNumber;
		candidate.LastName = candidateDto.LastName;
		candidate.Comment = candidateDto.FreeText;
		candidate.LinkedinUrl = candidateDto.LinkedInUrl;
		candidate.GithubUrl = candidateDto.GitHublUrl;
		candidate.Name = candidateDto.FirstName;
		_context.Candidates.Update(candidate);
		await _context.SaveChangesAsync();
		return candidate;
	}
}
