using Partify.Service.Configurations;
using Partify.Web.Models.AdCategories;

namespace Partify.Web.WebServices.AdCategories;

public interface IAdCategoryWebService
{
    ValueTask<AdCategoryViewModel> CreateAsync(AdCategoryCreateModel createModel);
    ValueTask<AdCategoryViewModel> UpdateAsync(long id, AdCategoryUpdateModel updateModel);
    ValueTask<bool> DeleteAsync(long id);
    ValueTask<AdCategoryViewModel> GetByIdAsync(long id);
    ValueTask<IEnumerable<AdCategoryViewModel>> GetAllAsync(PaginationParams @params, Filter filter, string search = null);
    ValueTask<IEnumerable<AdCategoryViewModel>> GetAllAsync();
}
