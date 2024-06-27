using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Partify.Domain.Entities.Ads;

namespace Partify.DataAccess.EntityConfigurations;

public class AdImageEntityTypeConfiguration : IEntityTypeConfiguration<AdImage>
{
	public void Configure(EntityTypeBuilder<AdImage> builder)
	{
	}
}
