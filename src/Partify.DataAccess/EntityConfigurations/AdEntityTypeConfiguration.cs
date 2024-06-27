using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Partify.Domain.Entities.Ads;

namespace Partify.DataAccess.EntityConfigurations;

public class AdEntityTypeConfiguration : IEntityTypeConfiguration<Ad>
{
	public void Configure(EntityTypeBuilder<Ad> builder)
	{
		builder
			.HasMany(ad => ad.Facilities)
			.WithOne(adFacility => adFacility.Ad)
			.HasForeignKey(adFacility => adFacility.AdId);
		builder
			.HasMany(ad => ad.Scores)
			.WithOne(adScore => adScore.Ad)
			.HasForeignKey(adScore => adScore.AdId);

		builder.HasIndex(ad => ad.Id);
		builder.HasIndex(ad => ad.Title);
		builder.HasIndex(ad => ad.Price);
		builder.HasIndex(ad => ad.Address);
		builder.HasIndex(ad => ad.AdCategoryId);
	}
}