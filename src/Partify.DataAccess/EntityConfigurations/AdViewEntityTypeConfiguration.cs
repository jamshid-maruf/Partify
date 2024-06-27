using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Partify.Domain.Entities.Ads;

namespace Partify.DataAccess.EntityConfigurations;

public class AdViewEntityTypeConfiguration : IEntityTypeConfiguration<AdView>
{
	public void Configure(EntityTypeBuilder<AdView> builder)
	{
	}
}