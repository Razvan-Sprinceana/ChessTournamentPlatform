using ChessPlatform.Api.Entities.Enums;
using ChessPlatform.Api.Models;

namespace ChessPlatform.Api.Entities
{
	public class Tournament
	{
		public int Id { get; set; }
		public required string Name { get; set; }
		public required DateTime StartDate { get; set; }
		public required DateTime EndDate { get; set; }
		public TournamentState State { get; set; } = TournamentState.Draft;
		public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
		public int NumberOfRounds { get; set; }
		public int? MinRating { get; set; }
		public int? MaxRating { get; set; }
		public int OrganizerId { get; set; }
		public User Organizer { get; set; } = null!;

		public ICollection<TournamentRegistration> Registrations { get; set; } = new List<TournamentRegistration>();
		public ICollection<Game> Games { get; set; } = new List<Game>();

	}
}
