using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Partify.Domain.Entities.Ads;

namespace Partify.DataAccess.EntityConfigurations;

public class FavoriteAdEntityTypeConfiguration : IEntityTypeConfiguration<FavoriteAd>
{
	public void Configure(EntityTypeBuilder<FavoriteAd> builder)
	{
	}
}
