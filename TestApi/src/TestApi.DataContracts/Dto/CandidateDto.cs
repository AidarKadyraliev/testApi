namespace TestApi.DataContracts.Dto;

/// <summary>
///		Candidate dto
/// </summary>
public class CandidateDto
{
	/// <summary>
	///		First name
	/// </summary>
	public string FirstName { get; set; }

	/// <summary>
	///		Last name
	/// </summary>
	public string LastName { get; set; }

	/// <summary>
	///		Phone number
	/// </summary>
	public string PhoneNumber { get; set; }

	/// <summary>
	///		Email
	/// </summary>
	public string Email { get; set; }

	/// <summary>
	///		Start date
	/// </summary>
	public DateTime? StartDate { get; set; }

	/// <summary>
	///		End date
	/// </summary>
	public DateTime? EndDate { get; set;}

	/// <summary>
	///		LinkedIn url
	/// </summary>
	public string LinkedInUrl { get; set; }

	/// <summary>
	///		Github url
	/// </summary>
	public string GitHublUrl { get; set; }

	/// <summary>
	///		Free text
	/// </summary>
	public string FreeText { get; set; }
	public CandidateDto(string firstName, string lastName, string phoneNumber, string email, DateTime? startDate, DateTime? endDate, string linkedInUrl, string gitHublUrl, string freeText)
	{
		FirstName = firstName;
		LastName = lastName;
		PhoneNumber = phoneNumber;
		Email = email;
		StartDate = startDate;
		EndDate = endDate;
		LinkedInUrl = linkedInUrl;
		GitHublUrl = gitHublUrl;
		FreeText = freeText;
	}
}
