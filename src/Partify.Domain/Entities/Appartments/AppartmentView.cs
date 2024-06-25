using Partify.Domain.Commons;

namespace Partify.Domain.Entities.Appartments;

public class AppartmentView : Auditable
{
	public int ViewCount { get; set; }
	public long AppartmentId { get; set; }
	public Appartment Appartment { get; set; }
}
