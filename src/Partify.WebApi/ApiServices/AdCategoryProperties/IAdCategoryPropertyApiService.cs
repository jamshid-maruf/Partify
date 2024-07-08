using Partify.Service.Configurations;
using Partify.WebApi.Models.AdCategoryProperties;

namespace Partify.WebApi.ApiServices.AdCategoryProperties;

public interface IAdCategoryPropertyApiService
{
    ValueTask<AdCategoryPropertyViewModel> CreateAsync(AdCategoryPropertyCreateModel createModel);
    ValueTask<AdCategoryPropertyViewModel> UpdateAsync(long id, AdCategoryPropertyUpdateModel updateModel);
    ValueTask<bool> DeleteAsync(long id);
    ValueTask<AdCategoryPropertyViewModel> GetByIdAsync(long id);
    ValueTask<IEnumerable<AdCategoryPropertyViewModel>> GetAllByAdCategoryIdAsync(long categoryId);
    ValueTask<IEnumerable<AdCategoryPropertyViewModel>> GetAllAsync(
        PaginationParams @params,
        Filter filter,
        string search = null);
}
