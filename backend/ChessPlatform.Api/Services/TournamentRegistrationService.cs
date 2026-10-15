using ChessPlatform.Api.Data;
using ChessPlatform.Api.Entities;
using ChessPlatform.Api.Entities.Enums;
using Microsoft.EntityFrameworkCore;

namespace ChessPlatform.Api.Services;

public record RegistrationResult(bool Success, string? Error, TournamentRegistrationState? State)
{
	public static RegistrationResult Ok(TournamentRegistrationState state) => new(true, null, state);
	public static RegistrationResult Fail(string error, TournamentRegistrationState? state = null) => new(false, error, state);
}

public class TournamentRegistrationService(AppDbContext db)
{
	public async Task<RegistrationResult> RegisterAsync(int tournamentId, int userId, CancellationToken ct = default)
	{
		var tournament = await db.Tournaments.FirstOrDefaultAsync(t => t.Id == tournamentId, ct);
		if (tournament is null)
			return RegistrationResult.Fail("Tournament not found.");

		if (tournament.State != TournamentState.RegistrationOpen)
			return RegistrationResult.Fail("Registration is not open for this tournament.");

		var user = await db.Users.FirstOrDefaultAsync(u => u.Id == userId && u.IsActive, ct);
		if (user is null)
			return RegistrationResult.Fail("User not found.");

		var registration = await db.TournamentRegistrations
			.FirstOrDefaultAsync(r => r.TournamentId == tournamentId && r.UserId == userId, ct);

		if (registration is { State: TournamentRegistrationState.Registered })
			return RegistrationResult.Fail("You are already registered for this tournament.");

		var withinRange =
			(tournament.MinRating is null || user.Rating >= tournament.MinRating) &&
			(tournament.MaxRating is null || user.Rating <= tournament.MaxRating);

		var newState = withinRange
			? TournamentRegistrationState.Registered
			: TournamentRegistrationState.Rejected;

		if (registration is null)
		{
			registration = new TournamentRegistration { TournamentId = tournamentId, UserId = userId };
			db.TournamentRegistrations.Add(registration);
		}

		registration.State = newState;
		registration.RegisteredAt = DateTime.UtcNow;
		registration.UserRatingAtRegistration = user.Rating;

		await db.SaveChangesAsync(ct);

		return withinRange
			? RegistrationResult.Ok(newState)
			: RegistrationResult.Fail("Your rating is outside this tournament's allowed range.", newState);
	}
}