using TestApi.Repositories.UnitOfWork.Repositories;

namespace TestApi.Repositories.UnitOfWork;
public class UnitOfWork : IUnitOfWork, IDisposable
{
	private readonly CandidatesDbContext _context;
	private readonly Lazy<ICandidateRepository> _candidateRepository;

	public ICandidateRepository CandidateRepository => _candidateRepository.Value;

	private void Dispose(bool disposing)
	{
		if (disposing)
			_context.Dispose();
	}

	public void Dispose()
	{
		Dispose(true);
		GC.SuppressFinalize(this);
	}
}
