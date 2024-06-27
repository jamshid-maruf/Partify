using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Partify.Domain.Entities.Ads;

namespace Partify.DataAccess.EntityConfigurations;

public class AdFacilityEntityTypeConfiguration : IEntityTypeConfiguration<AdFacility>
{
	public void Configure(EntityTypeBuilder<AdFacility> builder)
	{
	}
}
