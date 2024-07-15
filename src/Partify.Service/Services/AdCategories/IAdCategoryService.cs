using Partify.Domain.Entities.Ads;
using Partify.Service.Configurations;

namespace Partify.Service.Services.AdCategories;

public interface IAdCategoryService
{
    ValueTask<AdCategory> CreateAsync(AdCategory adCategory);
    ValueTask<AdCategory> UpdateAsync(long id, AdCategory adCategory);
    ValueTask<bool> DeleteAsync(long id);
    ValueTask<AdCategory> GetByIdAsync(long id);
    ValueTask<IEnumerable<AdCategory>> GetAllAsync(
        PaginationParams @params,
        Filter filter,
        string search = null);
    ValueTask<IEnumerable<AdCategory>> GetAllAsync();
}
