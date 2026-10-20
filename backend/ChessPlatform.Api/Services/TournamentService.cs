using ChessPlatform.Api.Data;
using ChessPlatform.Api.Dtos;
using ChessPlatform.Api.Entities.Enums;
using Microsoft.EntityFrameworkCore;

namespace ChessPlatform.Api.Services
{
	public class TournamentService
	{
		private readonly AppDbContext _appDbContext;
		public TournamentService(AppDbContext appDbContext)
		{
			_appDbContext = appDbContext;
		}
		public async Task<List<TournamentDto>> GetTournamentsAsync( CancellationToken cancellationToken = default)
		{
			return await _appDbContext.Tournaments
			.OrderBy(t => t.StartDate)
			.Select(t => new TournamentDto(
				t.Id,
				t.Name,
				t.StartDate,
				t.EndDate,
				t.State,
				t.OrganizerId,
				t.Organizer.Username,
				t.NumberOfRounds,
				t.MinRating,
				t.MaxRating,
				t.Registrations.Count(r => r.State == TournamentRegistrationState.Registered)
			))
			.AsNoTracking()
			.ToListAsync(cancellationToken);
		}

		public async Task<TournamentDetailsDto?> GetTournamentByIdAsync(int id, CancellationToken ct = default)
		{
			return await _appDbContext.Tournaments
				.Where(t => t.Id == id)
				.Select(t => new TournamentDetailsDto(
					t.Id,
					t.Name,
					t.StartDate,
					t.EndDate,
					t.State,
					t.OrganizerId,
					t.Organizer.Username,
					t.NumberOfRounds,
					t.MinRating,
					t.MaxRating,
					t.Registrations
						.Where(r => r.State == TournamentRegistrationState.Registered)
						.OrderByDescending(r => r.UserRatingAtRegistration)
						.Select(r => new TournamentPlayerDto(
							r.UserId,
							r.User.Username,
							r.User.Rating
						))
						.ToList()
				))
				.FirstOrDefaultAsync(ct);
		}
	}
}
