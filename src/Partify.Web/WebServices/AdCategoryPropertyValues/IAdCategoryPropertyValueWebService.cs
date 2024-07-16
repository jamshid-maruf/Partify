using Partify.Service.Configurations;
using Partify.Web.Models.AdCategoryPropertyValues;

namespace Partify.Web.WebServices.AdCategoryPropertyValues;

public interface IAdCategoryPropertyValueWebService
{
    ValueTask<AdCategoryPropertyValueViewModel> CreateAsync(AdCategoryPropertyValueCreateModel createModel);
    ValueTask<AdCategoryPropertyValueViewModel> UpdateAsync(long id, AdCategoryPropertyValueUpdateModel updateModel);
    ValueTask<bool> DeleteAsync(long id);
    ValueTask<AdCategoryPropertyValueViewModel> GetByIdAsync(long id);
    ValueTask<IEnumerable<AdCategoryPropertyValueViewModel>> GetAllAsync(PaginationParams @params, Filter filter, string search = null);
    ValueTask<IEnumerable<AdCategoryPropertyValueViewModel>> GetAllAsync();
}
