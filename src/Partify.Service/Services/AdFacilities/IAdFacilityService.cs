using Partify.Domain.Entities.Ads;
using Partify.Service.Configurations;

namespace Partify.Service.Services.AdFacilities;

public interface IAdFacilityService
{
    ValueTask<AdFacility> CreateAsync(AdFacility facility);
    ValueTask<AdFacility> UpdateAsync(long id, AdFacility facility);
    ValueTask<bool> DeleteAsync(long id);
    ValueTask<AdFacility> GetByIdAsync(long id);
    ValueTask<IEnumerable<AdFacility>> GetAllByFacilityIdAsync(long facilityId);
    ValueTask<IEnumerable<AdFacility>> GetAllAsync(PaginationParams @params, Filter filter, string search = null);
}
