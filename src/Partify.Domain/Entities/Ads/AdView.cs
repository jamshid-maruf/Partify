using Partify.Domain.Commons;

namespace Partify.Domain.Entities.Ads;

public class AdView : Auditable
{
	public int ViewCount { get; set; }
	public long AdId { get; set; }
	public Ad Ad { get; set; }
}
