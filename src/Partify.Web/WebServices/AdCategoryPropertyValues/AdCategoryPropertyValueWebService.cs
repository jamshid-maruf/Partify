using AutoMapper;
using Partify.Domain.Entities.Ads;
using Partify.Service.Configurations;
using Partify.Service.Services.AdCategoryPropertyValues;
using Partify.Web.Models.AdCategoryPropertyValues;

namespace Partify.Web.WebServices.AdCategoryPropertyValues;

public class AdCategoryPropertyValueWebService(IAdCategoryPropertyValueService adCategoryPropertyValueService, IMapper mapper) : IAdCategoryPropertyValueWebService
{
    public async ValueTask<AdCategoryPropertyValueViewModel> CreateAsync(AdCategoryPropertyValueCreateModel createModel)
    {
        var createdAdCategory = await adCategoryPropertyValueService
            .CreateAsync(mapper.Map<AdCategoryPropertyValue>(createModel));
        return mapper.Map<AdCategoryPropertyValueViewModel>(createdAdCategory);
    }

    public async ValueTask<bool> DeleteAsync(long id)
    {
        return await adCategoryPropertyValueService.DeleteAsync(id);
    }

    public async ValueTask<IEnumerable<AdCategoryPropertyValueViewModel>> GetAllAsync(
    PaginationParams @params,
        Filter filter,
        string search = null)
    {
        var result = await adCategoryPropertyValueService.GetAllAsync(@params, filter, search);
        return mapper.Map<IEnumerable<AdCategoryPropertyValueViewModel>>(result);
    }
    public async ValueTask<IEnumerable<AdCategoryPropertyValueViewModel>> GetAllAsync()
    {
        var result = await adCategoryPropertyValueService.GetAllAsync();
        return mapper.Map<IEnumerable<AdCategoryPropertyValueViewModel>>(result);
    }

    public async ValueTask<AdCategoryPropertyValueViewModel> GetByIdAsync(long id)
    {
        var result = await adCategoryPropertyValueService.GetByIdAsync(id);
        return mapper.Map<AdCategoryPropertyValueViewModel>(result);
    }

    public async ValueTask<AdCategoryPropertyValueViewModel> UpdateAsync(long id, AdCategoryPropertyValueUpdateModel updateModel)
    {
        var updatedAdCategory = await adCategoryPropertyValueService.UpdateAsync(id, mapper.Map<AdCategoryPropertyValue>(updateModel));
        return mapper.Map<AdCategoryPropertyValueViewModel>(updatedAdCategory);
    }
}
