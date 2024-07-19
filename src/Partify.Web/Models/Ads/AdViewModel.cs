using Partify.Domain.Entities.Ads;
using Partify.Domain.Enums;
using Partify.Web.Models.AdCategories;
using Partify.Web.Models.AdCategoryPropertyValues;
using Partify.Web.Models.Users;

namespace Partify.Web.Models.Ads;

public class AdViewModel
{
    public long Id { get; set; }
    public string Title { get; set; }
    public string Address { get; set; }
    public string Description { get; set; }
    public long Phone { get; set; }
    public decimal Price { get; set; }
    public PostType Type { get; set; }
	public int ViewCount { get; set; }
    public PostStatus Status { get; set; }
    public UserViewModel Merchant { get; set; }
    public AdCategoryViewModel AdCategory { get; set; }
    public ICollection<AdCategoryPropertyValueViewModel> Properties { get; set; }
    public ICollection<AdImageViewModel> Images { get; set; }
    public ICollection<AdCommentViewModel> Comments { get; set; }
    public ICollection<AdFacilityViewModel> Facilities { get; set; }
    public ICollection<AdScoreViewModel> Scores { get; set; }
}