using Partify.Domain.Entities.Ads;
using Partify.Service.Configurations;

namespace Partify.Service.Services.AdCategoryPropertyValues;

public interface IAdCategoryPropertyValueService
{
    ValueTask<AdCategoryPropertyValue> CreateAsync(AdCategoryPropertyValue adCategoryPropertyValue);
    ValueTask<AdCategoryPropertyValue> UpdateAsync(long id, AdCategoryPropertyValue adCategoryPropertyValue);
    ValueTask<bool> DeleteAsync(long id);
    ValueTask<AdCategoryPropertyValue> GetByIdAsync(long id);
    ValueTask<IEnumerable<AdCategoryPropertyValue>> GetAllAsync(
        PaginationParams @params,
        Filter filter,
        string search = null);
    ValueTask<IEnumerable<AdCategoryPropertyValue>> GetAllAsync();
}
