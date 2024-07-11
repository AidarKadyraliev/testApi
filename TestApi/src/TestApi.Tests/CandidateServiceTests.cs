using Moq;
using TestApi.DataContracts.Dto;
using TestApi.Domain;
using TestApi.Handlers.Services;
using TestApi.Repositories.UnitOfWork;
using TestApi.Repositories.UnitOfWork.Repositories;

namespace TestApi.Tests;

public class CandidateServiceTests
{
	private readonly Mock<ICandidateRepository> _candidateRepositoryMock;
	private readonly Mock<IUnitOfWork> _unitOfWorkMock;
	private readonly CandidateService _candidateService;

	public CandidateServiceTests()
	{
		_candidateRepositoryMock = new Mock<ICandidateRepository>();
		_unitOfWorkMock = new Mock<IUnitOfWork>();
		_unitOfWorkMock.Setup(uow => uow.CandidateRepository).Returns(_candidateRepositoryMock.Object);
		_candidateService = new CandidateService(_unitOfWorkMock.Object);
	}

	[Fact]
	public async Task CreateAsync_ShouldCreateCandidate()
	{
		// Arrange
		var candidateDto = new CandidateDto(
			 "John",
			"Doe",
			 "1234567890",
			"john.doe@example.com",
			 DateTime.UtcNow,
			DateTime.UtcNow.AddDays(1),
			"Some comment",
			"https://github.com/johndoe",
			"https://linkedin.com/in/johndoe"
		);

		_candidateRepositoryMock
			.Setup(repo => repo.CreateAsync(It.IsAny<Candidate>()))
			.ReturnsAsync((Candidate c) => c);

		// Act
		var result = await _candidateService.CreateAsync(candidateDto);

		// Assert
		Assert.NotNull(result);
		Assert.Equal(candidateDto.FirstName, result.Name);
		Assert.Equal(candidateDto.LastName, result.LastName);
		_candidateRepositoryMock.Verify(repo => repo.CreateAsync(It.IsAny<Candidate>()), Times.Once);
	}

	[Fact]
	public async Task GetCandidateAsync_ShouldReturnCandidate()
	{
		// Arrange
		var candidateId = Guid.NewGuid();
		var candidate = new Candidate { Id = candidateId };

		_candidateRepositoryMock
			.Setup(repo => repo.GetCandidateAsync(It.IsAny<Guid>()))
			.ReturnsAsync(candidate);

		// Act
		var result = await _candidateService.GetCandidateAsync(candidateId);

		// Assert
		Assert.NotNull(result);
		Assert.Equal(candidateId, result.Id);
		_candidateRepositoryMock.Verify(repo => repo.GetCandidateAsync(candidateId), Times.Once);
	}

	[Fact]
	public async Task GetCandidatesAsync_ShouldReturnCandidates()
	{
		// Arrange
		var cancellationToken = new CancellationToken();
		var candidates = new List<Candidate> { new Candidate(), new Candidate() };

		_candidateRepositoryMock
			.Setup(repo => repo.GetCandidatesAsync(It.IsAny<CancellationToken>()))
			.ReturnsAsync(candidates);

		// Act
		var result = await _candidateService.GetCandidatesAsync(cancellationToken);

		// Assert
		Assert.NotNull(result);
		Assert.Equal(2, result.Count());
		_candidateRepositoryMock.Verify(repo => repo.GetCandidatesAsync(cancellationToken), Times.Once);
	}

	[Fact]
	public async Task UpdateAsync_ShouldUpdateCandidate()
	{
		// Arrange
		var candidateId = Guid.NewGuid();
		var candidateDto = new CandidateDto(
			 "John",
			 "Doe",
			 "1234567890",
			 "john.doe@example.com",
			 DateTime.UtcNow,
			 DateTime.UtcNow.AddDays(1),
			 "Updated comment",
			 "https://github.com/johndoe",
			 "https://linkedin.com/in/johndoe"
		);
		var candidate = new Candidate
		{
			Id = candidateId,
			Name = candidateDto.FirstName,
			LastName = candidateDto.LastName,
			PhoneNumber = candidateDto.PhoneNumber,
			StartTime = candidateDto.StartDate,
			EndTime = candidateDto.EndDate,
			Comment = candidateDto.FreeText,
			Email = candidateDto.Email,
			GithubUrl = candidateDto.GitHublUrl,
			LinkedinUrl = candidateDto.LinkedInUrl
		};

		_candidateRepositoryMock
			.Setup(repo => repo.UpdateAsync(It.IsAny<Guid>(), It.IsAny<CandidateDto>()))
			.ReturnsAsync(candidate);

		// Act
		var result = await _candidateService.UpdateAsync(candidateId, candidateDto);

		// Assert
		Assert.NotNull(result);
		Assert.Equal(candidateDto.FirstName, result.Name);
		Assert.Equal(candidateDto.LastName, result.LastName);
		_candidateRepositoryMock.Verify(repo => repo.UpdateAsync(candidateId, candidateDto), Times.Once);
	}
}
