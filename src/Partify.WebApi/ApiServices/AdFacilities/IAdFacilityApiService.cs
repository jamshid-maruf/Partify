using Partify.Service.Configurations;
using Partify.WebApi.Models.AdFacilities;

namespace Partify.WebApi.ApiServices.AdFacilities;

public interface IAdFacilityApiService
{
    ValueTask<AdFacilityViewModel> CreateAsync(AdFacilityCreateModel createModel);
    ValueTask<AdFacilityViewModel> UpdateAsync(long id, AdFacilityUpdateModel updateModel);
    ValueTask<bool> DeleteAsync(long id);
    ValueTask<AdFacilityViewModel> GetByIdAsync(long id);
    ValueTask<IEnumerable<AdFacilityViewModel>> GetAllByFacilityIdAsync(long facilityId);
    ValueTask<IEnumerable<AdFacilityViewModel>> GetAllAsync(
        PaginationParams @params,
        Filter filter,
        string search = null);
}
