using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Partify.Domain.Entities.Users;

namespace Partify.DataAccess.EntityConfigurations;

public class UserRolePermissionEntityTypeConfiguration : IEntityTypeConfiguration<UserRolePermission>
{
	public void Configure(EntityTypeBuilder<UserRolePermission> builder)
	{
	}
}
