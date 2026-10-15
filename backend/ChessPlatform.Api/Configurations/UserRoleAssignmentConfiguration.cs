using ChessPlatform.Api.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChessPlatform.Api.Configurations
{
	public class UserRoleAssignmentConfiguration : IEntityTypeConfiguration<UserRoleAssignment>
	{
		public void Configure(EntityTypeBuilder<UserRoleAssignment> builder)
		{
			builder.ToTable("UserRoleAssignments");

			builder.HasKey(ura => new { ura.UserId, ura.Role });

			builder.HasOne(ura => ura.User)
				.WithMany(u => u.RoleAssignments)
				.HasForeignKey(ura => ura.UserId)
				.OnDelete(DeleteBehavior.Cascade);
		}
	}
}
