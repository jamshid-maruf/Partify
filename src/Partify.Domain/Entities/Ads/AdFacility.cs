using Partify.Domain.Commons;
using Partify.Domain.Entities.Facilities;

namespace Partify.Domain.Entities.Ads;

public class AdFacility : Auditable
{
	public long AdId { get; set; }
	public Ad Ad { get; set; }
	public long FacilityId { get; set; }
	public Facility Facility { get; set; }
}
