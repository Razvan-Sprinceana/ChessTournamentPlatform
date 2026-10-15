using ChessPlatform.Api.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChessPlatform.Api.Configurations
{
	public class TournamentRegistrationConfiguration : IEntityTypeConfiguration<TournamentRegistration>
	{
		public void Configure(EntityTypeBuilder<TournamentRegistration> builder)
		{
			builder.ToTable("TournamentRegistrations", t =>
			{
				t.HasCheckConstraint("CK_TournamentRegistrations_FinalPlacement_Positive",
					"[FinalPlacement] IS NULL OR [FinalPlacement] > 0");
			});

			builder.HasKey(r => new { r.TournamentId, r.UserId });

			builder.Property(r => r.FinalScore)
				.HasPrecision(4, 1);

			builder.HasOne(r => r.Tournament)
				.WithMany(t => t.Registrations)
				.HasForeignKey(r => r.TournamentId)
				.OnDelete(DeleteBehavior.Cascade);

			builder.HasOne(r => r.User)
				.WithMany(u => u.TournamentRegistrations)
				.HasForeignKey(r => r.UserId)
				.OnDelete(DeleteBehavior.Restrict);
		}
	}
}
