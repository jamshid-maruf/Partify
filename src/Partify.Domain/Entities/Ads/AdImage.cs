using Partify.Domain.Commons;
using Partify.Domain.Entities.Commons;

namespace Partify.Domain.Entities.Ads;

public class AdImage : Auditable
{
	public long AdId { get; set; }
	public Ad Ad { get; set; }
	public long ImageId { get; set; }
	public Asset Image { get; set; }
}
