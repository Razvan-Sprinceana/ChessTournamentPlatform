using ChessPlatform.Api.Data;
using ChessPlatform.Api.Entities;
using ChessPlatform.Api.Entities.Enums;
using Microsoft.EntityFrameworkCore;

namespace ChessPlatform.Api.Services;

public class TournamentCompletionService(AppDbContext db)
{
	/// <param name="ratingChanges">UserId → rating change for this tournament (from EloCalculator).</param>
	public async Task FinishTournamentAsync(
		int tournamentId,
		IReadOnlyDictionary<int, int> ratingChanges,
		CancellationToken ct = default)
	{
		await using var transaction = await db.Database.BeginTransactionAsync(ct);

		var tournament = await db.Tournaments.FirstOrDefaultAsync(t => t.Id == tournamentId, ct)
			?? throw new InvalidOperationException("Tournament not found.");

		if (tournament.State != TournamentState.InProgress)
			throw new InvalidOperationException("Only a tournament in progress can be finished.");

		tournament.State = TournamentState.Finished;
		await db.SaveChangesAsync(ct);

		foreach (var (userId, change) in ratingChanges)
		{
			var rowsAffected = await db.Users
				.Where(u => u.Id == userId)
				.ExecuteUpdateAsync(s => s.SetProperty(u => u.Rating, u => u.Rating + change), ct);

			if (rowsAffected == 0)
				throw new InvalidOperationException($"User {userId} not found.");

			var ratingAfter = await db.Users
				.Where(u => u.Id == userId)
				.Select(u => u.Rating)
				.SingleAsync(ct);

			db.RatingHistories.Add(new RatingHistory
			{
				UserId = userId,
				TournamentId = tournamentId,
				RatingBefore = ratingAfter - change,
				RatingAfter = ratingAfter,
				ChangedAt = DateTime.UtcNow
			});
		}

		await db.SaveChangesAsync(ct);
		await transaction.CommitAsync(ct);
	}
}