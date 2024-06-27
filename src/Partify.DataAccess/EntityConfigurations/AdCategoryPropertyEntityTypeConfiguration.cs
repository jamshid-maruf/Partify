using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Partify.Domain.Entities.Ads;

namespace Partify.DataAccess.EntityConfigurations;

public class AdCategoryPropertyEntityTypeConfiguration : IEntityTypeConfiguration<AdCategoryProperty>
{
	public void Configure(EntityTypeBuilder<AdCategoryProperty> builder)
	{
	}
}