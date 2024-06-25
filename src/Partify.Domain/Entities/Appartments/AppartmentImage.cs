using Partify.Domain.Commons;
using Partify.Domain.Entities.Commons;

namespace Partify.Domain.Entities.Appartments;

public class AppartmentImage : Auditable
{
	public long AppartmentId { get; set; }
	public Appartment Appartment { get; set; }
	public long ImageId { get; set; }
	public Asset Image { get; set; }
}
