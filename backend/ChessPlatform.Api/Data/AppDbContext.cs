using ChessPlatform.Api.Entities;
using ChessPlatform.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

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

			var utcConverter = new ValueConverter<DateTime, DateTime>(
				toDb => toDb.Kind == DateTimeKind.Local ? toDb.ToUniversalTime() : toDb,
				fromDb => DateTime.SpecifyKind(fromDb, DateTimeKind.Utc));

			foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetProperties()))
			{
				if (property.ClrType == typeof(DateTime) || property.ClrType == typeof(DateTime?))
				{
					property.SetValueConverter(utcConverter);
				}
			}
		}
	}
}
