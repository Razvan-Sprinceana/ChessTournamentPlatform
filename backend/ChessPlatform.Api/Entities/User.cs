using ChessPlatform.Api.Entities;
using ChessPlatform.Api.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace ChessPlatform.Api.Models
{
	public class User
	{
		public int Id { get; set; }
		public required string Username { get; set; }
		public required string Email { get; set; }
		public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
		public string? PasswordHash { get; set; }
		public int Rating { get; set; } = 1000;
		public bool IsActive { get; set; } = true;
		public ICollection<UserRoleAssignment> RoleAssignments { get; set; } = new List<UserRoleAssignment>();
		public ICollection<Tournament> OrganizedTournaments { get; set; } = new List<Tournament>();
		public ICollection<TournamentRegistration> TournamentRegistrations { get; set; } = new List<TournamentRegistration>();
		public ICollection<RatingHistory> RatingHistory { get; set; } = new List<RatingHistory>();
		public ICollection<Game> WhiteGames { get; set; } = new List<Game>();
		public ICollection<Game> BlackGames { get; set; } = new List<Game>();

	}
}
