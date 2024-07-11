using TestApi.Repositories.UnitOfWork.Repositories;

namespace TestApi.Repositories.UnitOfWork;
public interface IUnitOfWork
{
	/// <summary>
	///     Get generic repository
	/// </summary>
	/// <typeparam name="TEntity">Entity type</typeparam>
	/// <returns>Generic repository</returns>
	ICandidateRepository CandidateRepository { get; }
}
