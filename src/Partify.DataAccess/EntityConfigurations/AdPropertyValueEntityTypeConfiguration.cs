using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Partify.Domain.Entities.Ads;

namespace Partify.DataAccess.EntityConfigurations;

public class AdPropertyValueEntityTypeConfiguration : IEntityTypeConfiguration<AdCategoryPropertyValue>
{
	public void Configure(EntityTypeBuilder<AdCategoryPropertyValue> builder)
	{
	}
}
