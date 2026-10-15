using ChessPlatform.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChessPlatform.Api.Configurations
{
	public class UserConfiguration : IEntityTypeConfiguration<User>
	{
		public void Configure(EntityTypeBuilder<User> builder)
		{
			builder.ToTable("Users");

			builder.HasKey(u => u.Id);

			builder.Property(u => u.Username)
				.IsRequired()
				.HasMaxLength(50);

			builder.Property(u => u.Email)
				.IsRequired()
				.HasMaxLength(256);

			builder.Property(u => u.PasswordHash)
				.HasMaxLength(256);

			builder.HasIndex(u => u.Username)
				.IsUnique();

			builder.HasIndex(u => u.Email)
				.IsUnique();
		}
	}
}
