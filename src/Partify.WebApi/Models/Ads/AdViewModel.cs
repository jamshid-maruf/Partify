using Partify.Domain.Enums;
using Partify.WebApi.Models.AdCategories;

namespace Partify.WebApi.Models.Ads;

public class AdViewModel
{
	public long Id { get; set; }
	public string Title { get; set; }
	public string Address { get; set; }
	public string Description { get; set; }
	public long Phone { get; set; }
	public decimal Price { get; set; }
	public PostType Type { get; set; }
	public PostStatus Status { get; set; }
	public AdCategoryViewModel AdCategory { get; set; } 
}
