using Partify.WebApi.Models.Ads;
using Partify.WebApi.Models.Assets;

namespace Partify.WebApi.Models.AdImages;

public class AdImageViewModel
{
	public long Id { get; set; }
	public AdViewModel Ad { get; set; }
	public AssetViewModel Image { get; set; }
}
