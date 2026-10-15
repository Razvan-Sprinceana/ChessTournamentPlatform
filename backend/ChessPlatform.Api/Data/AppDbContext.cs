using ChessPlatform.Api.Entities;
using ChessPlatform.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace ChessPlatform.Api.Data
{
	public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
	{
		public DbSet<User> Users { get; set; }
		public DbSet<UserRoleAssignment> UserRoleAssignments { get; set; }
		public DbSet<Tournament> Tournaments => Set<Tournament>();
		public DbSet<TournamentRegistration> TournamentRegistrations => Set<TournamentRegistration>();
		public DbSet<RatingHistory> RatingHistories => Set<RatingHistory>();
		public DbSet<Game> Games => Set<Game>();

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
		}
	}
}
