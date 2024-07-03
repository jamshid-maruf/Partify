using Partify.Service.Configurations;
using Partify.WebApi.Models.FavoriteAds;

namespace Partify.WebApi.ApiServices.FavoriteAds;

public interface IFavoriteAdApiService
{
    ValueTask<FavoriteAdViewModel> CreateAsync(FavoriteAdCreateModel createModel);
    ValueTask<bool> DeleteAsync(long id);
    ValueTask<FavoriteAdViewModel> GetByIdAsync(long id);
    ValueTask<IEnumerable<FavoriteAdViewModel>> GetAllAsync(PaginationParams @params);
}