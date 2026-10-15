using ChessPlatform.Api.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChessPlatform.Api.Configurations
{
	public class TournamentConfiguration : IEntityTypeConfiguration<Tournament>
	{
		public void Configure(EntityTypeBuilder<Tournament> builder)
		{
			builder.ToTable("Tournaments", t =>
			{
				t.HasCheckConstraint("CK_Tournaments_EndDate_After_StartDate", "[EndDate] >= [StartDate]");
				t.HasCheckConstraint("CK_Tournaments_NumberOfRounds_Positive", "[NumberOfRounds] > 0");
				t.HasCheckConstraint("CK_Tournaments_RatingRange_Valid",
				"[MinRating] IS NULL OR [MaxRating] IS NULL OR [MinRating] <= [MaxRating]");
			});

			builder.HasKey(t => t.Id);
			builder.Property(t => t.Name)
				.IsRequired()
				.HasMaxLength(100);
			builder.Property(t => t.StartDate)
				.IsRequired();


			builder.HasOne(t => t.Organizer)
				.WithMany(u => u.OrganizedTournaments)
				.HasForeignKey(t => t.OrganizerId)
				.OnDelete(DeleteBehavior.Restrict);
		}
	}
}
