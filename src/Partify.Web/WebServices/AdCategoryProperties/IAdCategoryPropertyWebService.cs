using Partify.Service.Configurations;
using Partify.Web.Models.AdCategories;

namespace Partify.Web.WebServices.AdCategoryProperties;

public interface IAdCategoryPropertyWebService
{
    ValueTask<AdCategoryPropertyViewModel> CreateAsync(AdCategoryPropertyCreateModel createModel);
    ValueTask<AdCategoryPropertyViewModel> UpdateAsync(long id, AdCategoryPropertyUpdateModel updateModel);
    ValueTask<bool> DeleteAsync(long id);
    ValueTask<AdCategoryPropertyViewModel> GetByIdAsync(long id);
    ValueTask<IEnumerable<AdCategoryPropertyViewModel>> GetAllAsync(PaginationParams @params, Filter filter, string search = null);
    ValueTask<IEnumerable<AdCategoryPropertyViewModel>> GetAllAsync();
}

