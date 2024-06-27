using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Partify.Domain.Entities.Facilities;

namespace Partify.DataAccess.EntityConfigurations;

public class FacilityEntityTypeConfiguration : IEntityTypeConfiguration<Facility>
{
	public void Configure(EntityTypeBuilder<Facility> builder)
	{
	}
}
