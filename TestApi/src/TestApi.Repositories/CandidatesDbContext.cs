using Microsoft.EntityFrameworkCore;
using TestApi.Domain;

namespace TestApi.Repositories;
public class CandidatesDbContext : DbContext
{
	public CandidatesDbContext(DbContextOptions<CandidatesDbContext> options) : base(options) { }

	public DbSet<Candidate> Candidates { get; set; }

	/// <summary>
	///     Apply configurations 
	/// </summary>
	/// <param name="modelBuilder">Model builder</param>
	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfigurationsFromAssembly(typeof(CandidatesDbContext).Assembly);
		base.OnModelCreating(modelBuilder);
	}
}
