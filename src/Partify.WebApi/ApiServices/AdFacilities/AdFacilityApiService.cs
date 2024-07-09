using AutoMapper;
using Partify.Domain.Entities.Ads;
using Partify.Service.Configurations;
using Partify.Service.Services.AdFacilities;
using Partify.WebApi.Models.AdFacilities;

namespace Partify.WebApi.ApiServices.AdFacilities;

public class AdFacilityApiService(IAdFacilityService adFacilityService, IMapper mapper) : IAdFacilityApiService
{
    public async ValueTask<AdFacilityViewModel> CreateAsync(AdFacilityCreateModel createModel)
    {
        var createdAdFacility = await adFacilityService.CreateAsync(mapper.Map<AdFacility>(createModel));
        return mapper.Map<AdFacilityViewModel>(createdAdFacility);
    }

    public async ValueTask<bool> DeleteAsync(long id)
    {
        return await adFacilityService.DeleteAsync(id);
    }

    public async ValueTask<IEnumerable<AdFacilityViewModel>> GetAllAsync(PaginationParams @params, Filter filter, string search = null)
    {
        var result = await adFacilityService.GetAllAsync(@params, filter, search);
        return mapper.Map<IEnumerable<AdFacilityViewModel>>(result);
    }

    public async ValueTask<IEnumerable<AdFacilityViewModel>> GetAllByFacilityIdAsync(long facilityId)
    {
        var result = await adFacilityService.GetAllByFacilityIdAsync(facilityId);
        return mapper.Map<IEnumerable<AdFacilityViewModel>>(result);
    }

    public async ValueTask<AdFacilityViewModel> GetByIdAsync(long id)
    {
        var result = await adFacilityService.GetByIdAsync(id);
        return mapper.Map<AdFacilityViewModel>(result);
    }

    public async ValueTask<AdFacilityViewModel> UpdateAsync(long id, AdFacilityUpdateModel updateModel)
    {
        var updatedAdFacility = await adFacilityService.UpdateAsync(id, mapper.Map<AdFacility>(updateModel));
        return mapper.Map<AdFacilityViewModel>(updatedAdFacility);
    }
}