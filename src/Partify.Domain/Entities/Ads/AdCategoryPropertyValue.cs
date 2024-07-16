using Partify.Domain.Commons;

namespace Partify.Domain.Entities.Ads;

public class AdCategoryPropertyValue : Auditable
{
	public long AdCategoryPropertyId { get; set; }
	public AdCategoryProperty AdCategoryProperty { get; set; }
	public string Value { get; set; }
}