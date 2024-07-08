﻿using AutoMapper;
using Partify.Domain.Entities.Ads;
using Partify.Service.Configurations;
using Partify.Service.Services.AdCategoryProperties;
using Partify.WebApi.Models.AdCategoryProperties;

namespace Partify.WebApi.ApiServices.AdCategoryProperties;

public class AdCategoryPropertyApiService(IAdCategoryPropertyService adCategoryPropertyService, IMapper mapper) : IAdCategoryPropertyApiService
{
    public async ValueTask<AdCategoryPropertyViewModel> CreateAsync(AdCategoryPropertyCreateModel createModel)
    {
        var createdAdCategoryProperty = await adCategoryPropertyService.CreateAsync(mapper.Map<AdCategoryProperty>(createModel));
        return mapper.Map<AdCategoryPropertyViewModel>(createdAdCategoryProperty);
    }

    public async ValueTask<bool> DeleteAsync(long id)
    {
        return await adCategoryPropertyService.DeleteAsync(id);
    }

    public async ValueTask<IEnumerable<AdCategoryPropertyViewModel>> GetAllAsync(
        PaginationParams @params,
        Filter filter,
        string search = null)
    {
        var result = await adCategoryPropertyService.GetAllAsync(@params, filter, search);
        return mapper.Map<IEnumerable<AdCategoryPropertyViewModel>>(result);
    }

    public async ValueTask<IEnumerable<AdCategoryPropertyViewModel>> GetAllByAdCategoryIdAsync(long categoryId)
    {
        var result = await adCategoryPropertyService.GetAllByAdCategoryIdAsync(categoryId);
        return mapper.Map<IEnumerable<AdCategoryPropertyViewModel>>(result);
    }

    public async ValueTask<AdCategoryPropertyViewModel> GetByIdAsync(long id)
    {
        var result = await adCategoryPropertyService.GetByIdAsync(id);
        return mapper.Map<AdCategoryPropertyViewModel>(result);
    }

    public async ValueTask<AdCategoryPropertyViewModel> UpdateAsync(long id, AdCategoryPropertyUpdateModel updateModel)
    {
        var updatedAdCategoryProperty = await adCategoryPropertyService.UpdateAsync(id, mapper.Map<AdCategoryProperty>(updateModel));
        return mapper.Map<AdCategoryPropertyViewModel>(updatedAdCategoryProperty);
    }
}
