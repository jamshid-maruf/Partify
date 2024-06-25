using Partify.Domain.Commons;
using Partify.Domain.Entities.Facilities;

namespace Partify.Domain.Entities.Appartments;

public class AppartmentFacility : Auditable
{
	public long AppartmentId { get; set; }
	public Appartment Appartment { get; set; }
	public long FacilityId { get; set; }
	public Facility Facility { get; set; }
}
