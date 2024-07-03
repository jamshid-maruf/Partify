using Partify.WebApi.Models.Ads;

namespace Partify.WebApi.Models.AdViews;

public class AdViewViewModel
{
	public long Id { get; set; }
	public int ViewCount { get; set; }
	public AdViewModel Ad { get; set; }
}
