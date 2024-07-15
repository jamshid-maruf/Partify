using AutoMapper;
using Partify.Domain.Entities.Ads;
using Partify.Service.Configurations;
using Partify.Service.Services.AdCategories;
using Partify.Web.Models.AdCategories;

namespace Partify.Web.WebServices.AdCategories;

public class AdCategoryWebService(IAdCategoryService adCategoryService, IMapper mapper) : IAdCategoryWebService
{
    public async ValueTask<AdCategoryViewModel> CreateAsync(AdCategoryCreateModel createModel)
    {
        var createdAdCategory = await adCategoryService.CreateAsync(mapper.Map<AdCategory>(createModel));
        return mapper.Map<AdCategoryViewModel>(createdAdCategory);
    }

    public async ValueTask<bool> DeleteAsync(long id)
    {
        return await adCategoryService.DeleteAsync(id);
    }

    public async ValueTask<IEnumerable<AdCategoryViewModel>> GetAllAsync(
    PaginationParams @params,
        Filter filter,
        string search = null)
    {
        var result = await adCategoryService.GetAllAsync(@params, filter, search);
        return mapper.Map<IEnumerable<AdCategoryViewModel>>(result);
    }
    public async ValueTask<IEnumerable<AdCategoryViewModel>> GetAllAsync()
    {
        var result = await adCategoryService.GetAllAsync();
        return mapper.Map<IEnumerable<AdCategoryViewModel>>(result);
    }

    public async ValueTask<AdCategoryViewModel> GetByIdAsync(long id)
    {
        var result = await adCategoryService.GetByIdAsync(id);
        return mapper.Map<AdCategoryViewModel>(result);
    }

    public async ValueTask<AdCategoryViewModel> UpdateAsync(long id, AdCategoryUpdateModel updateModel)
    {
        var updatedAdCategory = await adCategoryService.UpdateAsync(id, mapper.Map<AdCategory>(updateModel));
        return mapper.Map<AdCategoryViewModel>(updatedAdCategory);
    }
}
