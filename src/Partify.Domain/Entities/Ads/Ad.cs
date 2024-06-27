using Partify.Domain.Commons;
using Partify.Domain.Entities.Users;
using Partify.Domain.Enums;

namespace Partify.Domain.Entities.Ads;

public class Ad : Auditable
{
	public string Title { get; set; }
	public string Address { get; set; }
	public string Description { get; set; }
	public long Phone { get; set; }
	public decimal Price { get; set; }
	public PostType Type { get; set; }
	public PostStatus Status { get; set; }
	public long MerchantId { get; set; }
	public Merchant Merchant { get; set; }
	public long AdCategoryId { get; set; }
	public AdCategory AdCategory { get; set; }
	public ICollection<AdPropertyValue> Properties { get; set; }
	public ICollection<AdImage> Images { get; set; }
	public ICollection<AdComment> Comments { get; set; }
	public ICollection<AdFacility> Facilities { get; set; }
	public ICollection<AdScore> Scores { get; set; }
}
