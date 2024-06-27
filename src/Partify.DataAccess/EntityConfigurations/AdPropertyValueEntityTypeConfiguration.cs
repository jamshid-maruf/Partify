using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Partify.Domain.Entities.Ads;

namespace Partify.DataAccess.EntityConfigurations;

public class AdPropertyValueEntityTypeConfiguration : IEntityTypeConfiguration<AdPropertyValue>
{
	public void Configure(EntityTypeBuilder<AdPropertyValue> builder)
	{
	}
}
