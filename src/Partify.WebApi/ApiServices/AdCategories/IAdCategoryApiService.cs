using Partify.Service.Configurations;
using Partify.WebApi.Models.AdCategories;

namespace Partify.WebApi.ApiServices.AdCategories;

public interface IAdCategoryApiService
{
    ValueTask<AdCategoryViewModel> CreateAsync(AdCategoryCreateModel createModel);
    ValueTask<AdCategoryViewModel> UpdateAsync(long id, AdCategoryUpdateModel updateModel);
    ValueTask<bool> DeleteAsync(long id);
    ValueTask<AdCategoryViewModel> GetByIdAsync(long id);
    ValueTask<IEnumerable<AdCategoryViewModel>> GetAllAsync(PaginationParams @params, Filter filter, string search = null);
}
