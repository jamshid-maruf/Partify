using Partify.Domain.Entities.Ads;
using Partify.Domain.Entities.Users;

namespace Partify.WebApi.Models.FavoriteAds;

public class FavoriteAdCreateModel
{
    public long UserId { get; set; }
    public long AdId { get; set; }
}
