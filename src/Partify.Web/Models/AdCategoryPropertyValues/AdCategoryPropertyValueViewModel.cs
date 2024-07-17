using Partify.Web.Models.AdCategories;
using Partify.WebApi.Models.AdCategoryProperties;

namespace Partify.Web.Models.AdCategoryPropertyValues;

public class AdCategoryPropertyValueViewModel
{
    public long Id { get; set; }
    public AdCategoryPropertyViewModel AdCategory { get; set; }
    public string Value { get; set; }
}
