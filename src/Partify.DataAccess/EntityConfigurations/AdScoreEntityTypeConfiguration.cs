using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Partify.Domain.Entities.Ads;

namespace Partify.DataAccess.EntityConfigurations;

public class AdScoreEntityTypeConfiguration : IEntityTypeConfiguration<AdScore>
{
	public void Configure(EntityTypeBuilder<AdScore> builder)
	{
	}
}