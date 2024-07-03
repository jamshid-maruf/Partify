using Partify.WebApi.Models.Ads;
using Partify.WebApi.Models.Users;

namespace Partify.WebApi.Models.FavoriteAds;

public class FavoriteAdViewModel
{
	public long Id { get; set; }
	public UserViewModel User { get; set; }
	public AdViewModel Ad { get; set; }
}
