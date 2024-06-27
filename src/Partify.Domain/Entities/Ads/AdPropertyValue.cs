using Partify.Domain.Commons;

namespace Partify.Domain.Entities.Ads;

public class AdPropertyValue : Auditable
{
	public long AdCategoryPropertyId { get; set; }
	public string Value { get; set; }
}