using ChessPlatform.Api.Entities.Enums;

namespace ChessPlatform.Api.Dtos
{
	public record TournamentPlayerDto(
		int UserId,
		string Username,
		int RatingAtRegistration);

	public record TournamentDetailsDto(
		int Id,
		string Name,
		DateTime StartDate,
		DateTime EndDate,
		TournamentState State,
		int OrganizerId,
		string OrganizerName,
		int NumberOfRounds,
		int? MinRating,
		int? MaxRating,
		List<TournamentPlayerDto> Players);
	
}
