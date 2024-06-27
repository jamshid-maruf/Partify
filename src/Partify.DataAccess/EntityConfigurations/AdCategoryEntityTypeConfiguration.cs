using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Partify.Domain.Entities.Ads;

namespace Partify.DataAccess.EntityConfigurations;

public class AdCategoryEntityTypeConfiguration : IEntityTypeConfiguration<AdCategory>
{
	public void Configure(EntityTypeBuilder<AdCategory> builder)
	{
	}
}