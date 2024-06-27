using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Partify.Domain.Entities.Users;

namespace Partify.DataAccess.EntityConfigurations;

public class MerchantEntityTypeConfiguration : IEntityTypeConfiguration<Merchant>
{
	public void Configure(EntityTypeBuilder<Merchant> builder)
	{
	}
}
