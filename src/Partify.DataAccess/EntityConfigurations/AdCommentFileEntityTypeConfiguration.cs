using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Partify.Domain.Entities.Ads;

namespace Partify.DataAccess.EntityConfigurations;

public class AdCommentFileEntityTypeConfiguration : IEntityTypeConfiguration<AdCommentFile>
{
	public void Configure(EntityTypeBuilder<AdCommentFile> builder)
	{
	}
}