using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Partify.Domain.Entities.Ads;

namespace Partify.DataAccess.EntityConfigurations;

public class AdCommentEntityTypeConfiguration : IEntityTypeConfiguration<AdComment>
{
	public void Configure(EntityTypeBuilder<AdComment> builder)
	{
	}
}
