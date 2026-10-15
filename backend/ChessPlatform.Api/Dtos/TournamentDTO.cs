using ChessPlatform.Api.Data;
using ChessPlatform.Api.Entities.Enums;
using Microsoft.EntityFrameworkCore;

namespace ChessPlatform.Api.Dtos
{
	public record TournamentDto(
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
		int NumberOfPlayers);

}
