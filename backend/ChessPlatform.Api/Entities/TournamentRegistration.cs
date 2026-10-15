using ChessPlatform.Api.Entities.Enums;
using ChessPlatform.Api.Models;

namespace ChessPlatform.Api.Entities
{
	public class TournamentRegistration
	{
		public int TournamentId { get; set; }
		public Tournament Tournament { get; set; } = null!;

		public int UserId { get; set; }
		public User User { get; set; } = null!;

		public TournamentRegistrationState State { get; set; }
		public DateTime RegisteredAt { get; set; } = DateTime.UtcNow;
		public int UserRatingAtRegistration { get; set; }
		public decimal? FinalScore { get; set; }
		public int? FinalPlacement { get; set; }
	}
}
