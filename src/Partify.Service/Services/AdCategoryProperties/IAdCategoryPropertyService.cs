using Partify.Domain.Entities.Ads;
using Partify.Service.Configurations;

namespace Partify.Service.Services.AdCategoryProperties;

public interface IAdCategoryPropertyService
{
    ValueTask<AdCategoryProperty> CreateAsync(AdCategoryProperty adCategoryProperty);
    ValueTask<AdCategoryProperty> UpdateAsync(long id, AdCategoryProperty adCategoryProperty);
    ValueTask<bool> DeleteAsync(long id);
    ValueTask<AdCategoryProperty> GetByIdAsync(long id);
    ValueTask<IEnumerable<AdCategoryProperty>> GetAllByAdCategoryIdAsync(long categoryId);
    ValueTask<IEnumerable<AdCategoryProperty>> GetAllAsync(
        PaginationParams @params,
        Filter filter,
        string search = null);
}
