using ChessPlatform.Api.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChessPlatform.Api.Configurations
{
	public class RatingHistoryConfiguration : IEntityTypeConfiguration<RatingHistory>
	{
		public void Configure(EntityTypeBuilder<RatingHistory> builder)
		{
			builder.ToTable("RatingHistories");

			builder.HasKey(rh => rh.Id);

			builder.HasOne(rh => rh.User)
				.WithMany(u => u.RatingHistory)
				.HasForeignKey(rh => rh.UserId)
				.OnDelete(DeleteBehavior.Restrict);

			builder.HasOne(rh => rh.Tournament)
				.WithMany()
				.HasForeignKey(rh => rh.TournamentId)
				.OnDelete(DeleteBehavior.Restrict);

			builder.HasIndex(rh => new { rh.UserId, rh.TournamentId })
				.IsUnique();

			builder.HasIndex(rh => new { rh.UserId, rh.ChangedAt });
		}
	}
}
