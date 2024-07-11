namespace TestApi.Domain;
public class Candidate
{
	public Guid Id { get; set; }

	/// <summary>
	///		Name of Candidate
	/// </summary>
	public string Name { get; set; } = null!;
	/// <summary>
	///		LastName of Candidate
	/// </summary>
	public string LastName { get; set; } = null!;
	/// <summary>
	///		Phone number of Candidate
	/// </summary>
	public string PhoneNumber { get; set; } = null!;
	/// <summary>
	///		Candidate Email
	/// </summary>
	public string Email { get; set; } = null!;

	/// <summary>
	///		Interval StartTime
	/// </summary>
	public DateTime? StartTime { get; set; }
	/// <summary>
	///		Interval Endtime
	/// </summary>
	public DateTime? EndTime { get; set; }
	/// <summary>
	///		Candidate linkedin url
	/// </summary>
	public string LinkedinUrl { get; set; } = null!;

	/// <summary>
	///		Candidate github url
	/// </summary>
	public string GithubUrl { get; set; } = null!;

	/// <summary>
	///		Free text comment
	/// </summary>
	public string Comment { get; set; } = null!;

	/// <summary>
	///		Created at
	/// </summary>
	public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
