using Partify.Domain.Commons;

namespace Partify.Domain.Entities.Ads;

public class AdCategoryProperty : Auditable
{
	public string Name { get; set; }
	public long AdCategoryId { get; set; }
	public AdCategory AdCategory { get; set; }
}
