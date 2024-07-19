using Partify.Domain.Enums;
using Partify.Web.Models.AdCategoryPropertyValues;

namespace Partify.Web.Models.Ads;

public class AdUpdateModel
{
    public string Title { get; set; }
    public string Address { get; set; }
    public string Description { get; set; }
    public long Phone { get; set; }
    public decimal Price { get; set; }
    public PostType Type { get; set; }
    public long AdCategoryId { get; set; }
    public List<AdCategoryPropertyValueCreateModel> Properties { get; set; }
    public List<AdImageCreateModel> Images { get; set; }
    public List<AdFacilityCreateModel> Facilities { get; set; }
}