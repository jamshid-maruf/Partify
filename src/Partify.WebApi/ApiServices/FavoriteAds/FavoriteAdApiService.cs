using AutoMapper;
using Partify.Domain.Entities.Ads;
using Partify.Service.Configurations;
using Partify.Service.Services.FavoriteAds;
using Partify.WebApi.Models.FavoriteAds;

namespace Partify.WebApi.ApiServices.FavoriteAds;

public class FavoriteAdApiService(IMapper mapper, IFavoriteAdService favoriteAdService) : IFavoriteAdApiService
{
    public async ValueTask<FavoriteAdViewModel> CreateAsync(FavoriteAdCreateModel createModel)
    {
        var createdFavoriteAd = await favoriteAdService.CreateAsync(mapper.Map<FavoriteAd>(createModel));
        return mapper.Map<FavoriteAdViewModel>(createdFavoriteAd);
    }

    public ValueTask<bool> DeleteAsync(long id)
    {
        return favoriteAdService.DeleteAsync(id);
    }

    public async ValueTask<IEnumerable<FavoriteAdViewModel>> GetAllAsync(PaginationParams @params)
    {
        var favoriteAds = await favoriteAdService.GetAllAsync(@params);
        return mapper.Map<IEnumerable<FavoriteAdViewModel>>(favoriteAds);
    }

    public async ValueTask<FavoriteAdViewModel> GetByIdAsync(long id)
    {
        var favoriteAd = await favoriteAdService.GetByIdAsync(id);
        return mapper.Map<FavoriteAdViewModel>(favoriteAd);
    }
}
