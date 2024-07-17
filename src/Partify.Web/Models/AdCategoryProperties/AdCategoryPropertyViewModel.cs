using Partify.Domain.Entities.Ads;

namespace Partify.Web.Models.AdCategories
{
    public class AdCategoryPropertyViewModel
    {
        public string Name { get; set; }
        public AdCategoryViewModel AdCategory { get; set; }
    }
}
