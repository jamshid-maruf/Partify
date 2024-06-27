using Partify.Domain.Commons;
using Partify.Domain.Entities.Users;

namespace Partify.Domain.Entities.Ads;

public class FavoriteAd : Auditable
{
	public long UserId { get; set; }
	public User User { get; set; }
	public long AdId { get; set; }
	public Ad Ad { get; set; }
}