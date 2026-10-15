using ChessPlatform.Api.Entities.Enums;
using ChessPlatform.Api.Models;

namespace ChessPlatform.Api.Entities
{
	public class Game
	{
		public int Id { get; set; }
		public int WhitePlayerId { get; set; }
		public User WhitePlayer { get; set; } = null!;
		public int BlackPlayerId { get; set; }
		public User BlackPlayer { get; set; } = null!;
		public DateTime? PlayedAt { get; set; }
		public GameResult Result { get; set; } = GameResult.NotPlayed;
		public int TournamentId { get; set; }
		public Tournament Tournament { get; set; } = null!;
		public int Round { get; set; }
	}
}
