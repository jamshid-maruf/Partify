using Partify.Domain.Entities.Ads;
using Partify.Service.Configurations;

namespace Partify.Service.Services.FavoriteAds;

public interface IFavoriteAdService
{
	ValueTask<FavoriteAd> CreateAsync(FavoriteAd favoriteAd);
	ValueTask<bool> DeleteAsync(long id);
	ValueTask<FavoriteAd> GetByIdAsync(long id);
	ValueTask<IEnumerable<FavoriteAd>> GetAllAsync(PaginationParams @params);
}