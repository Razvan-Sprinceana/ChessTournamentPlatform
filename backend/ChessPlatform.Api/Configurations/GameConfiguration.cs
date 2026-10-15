using ChessPlatform.Api.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChessPlatform.Api.Configurations
{
	public class GameConfiguration : IEntityTypeConfiguration<Game>
	{
		public void Configure(EntityTypeBuilder<Game> builder)
		{
			builder.ToTable("Games", g =>
			{
				g.HasCheckConstraint("CK_Games_Round_Positive", "[Round] > 0");
				g.HasCheckConstraint("CK_Games_WhiteAndBlack_Different", "[WhitePlayerId] <> [BlackPlayerId]");

			});

			builder.HasKey(g => g.Id);

			builder.HasOne(g => g.Tournament)
				.WithMany(t => t.Games)
				.HasForeignKey(g => g.TournamentId)
				.OnDelete(DeleteBehavior.Cascade);

			builder.HasOne(g => g.WhitePlayer)
				.WithMany(u => u.WhiteGames)
				.HasForeignKey(g => g.WhitePlayerId)
				.OnDelete(DeleteBehavior.Restrict);

			builder.HasOne(g => g.BlackPlayer)
				.WithMany(u => u.BlackGames)
				.HasForeignKey(g => g.BlackPlayerId)
				.OnDelete(DeleteBehavior.Restrict);

			builder.HasIndex(g => new { g.TournamentId, g.Round });
		}
	}
}
