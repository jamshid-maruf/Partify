using Partify.WebApi.Models.AdCategories;

namespace Partify.WebApi.Models.AdCategoryProperties;

public class AdCategoryPropertyViewModel
{
    public long Id { get; set; }
    public string Name { get; set; }
    public AdCategoryViewModel AdCategory { get; set; }
}