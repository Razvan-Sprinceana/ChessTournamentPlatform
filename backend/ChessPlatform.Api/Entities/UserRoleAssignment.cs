using ChessPlatform.Api.Entities.Enums;
using ChessPlatform.Api.Models;

namespace ChessPlatform.Api.Entities
{
	public class UserRoleAssignment
	{
		public int UserId { get; set; }
		public UserRole Role { get; set; }
		public User User { get; set; } = null!;
	}
}
