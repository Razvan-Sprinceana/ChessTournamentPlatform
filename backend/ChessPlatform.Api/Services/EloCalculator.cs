namespace ChessPlatform.Api.Services
{
	public static class EloCalculator
	{
		public const int DefaultKFactor = 32;

		public static double ExpectedScore(int rating, int opponentRating) =>
			1.0 / (1.0 + Math.Pow(10, (opponentRating - rating) / 400.0));

		/// <summary>
		/// Rating change for a whole tournament, using the player's rating from the start of the tournament
		/// (UserRatingAtRegistration) for every game, the way FIDE does. Score: 1 = win, 0.5 = draw, 0 = loss.
		/// </summary>
		public static int TournamentRatingChange(
			int startingRating,
			IEnumerable<(int OpponentStartingRating, double Score)> games,
			int kFactor = DefaultKFactor)
		{
			var total = games.Sum(g => kFactor * (g.Score - ExpectedScore(startingRating, g.OpponentStartingRating)));
			return (int)Math.Round(total);
		}
	}
}
