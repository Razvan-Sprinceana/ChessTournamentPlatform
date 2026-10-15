using ChessPlatform.Api.Models;

namespace ChessPlatform.Api.Entities
{
	public class RatingHistory
	{
		public int Id { get; set; }
		public int UserId { get; set; }
		public User User { get; set; } = null!;
		public int? TournamentId { get; set; }
		public Tournament? Tournament { get; set; }
		public int RatingBefore { get; set; }
		public int RatingAfter { get; set; }
		public DateTime ChangedAt { get; set; } = DateTime.UtcNow;
	}
}
