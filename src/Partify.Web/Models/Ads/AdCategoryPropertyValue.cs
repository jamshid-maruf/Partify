using Partify.Domain.Entities.Ads;

namespace Partify.Web.Models.Ads;

public class AdCategoryPropertyValue
{
    public long AdCategoryPropertyId { get; set; }
    public AdCategoryProperty AdCategoryProperty { get; set; }
    public string Value { get; set; }
}
