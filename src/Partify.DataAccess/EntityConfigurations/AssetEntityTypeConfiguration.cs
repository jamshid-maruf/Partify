using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Partify.Domain.Entities.Commons;

namespace Partify.DataAccess.EntityConfigurations;

public class AssetEntityTypeConfiguration : IEntityTypeConfiguration<AssetViewModel>
{
	public void Configure(EntityTypeBuilder<AssetViewModel> builder)
	{
	}
}