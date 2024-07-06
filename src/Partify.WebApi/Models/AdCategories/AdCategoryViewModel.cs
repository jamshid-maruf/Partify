using Partify.Domain.Entities.Ads;
using Partify.WebApi.Models.Ads;

namespace Partify.WebApi.Models.AdCategories
{
    public class AdCategoryViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<AdViewModel> Ads { get; set; }
    }
}
