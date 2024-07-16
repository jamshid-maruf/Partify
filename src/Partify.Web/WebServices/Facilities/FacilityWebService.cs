using AutoMapper;
using Partify.Domain.Entities.Facilities;
using Partify.Service.Configurations;
using Partify.Service.Services.Facilities;
using Partify.Web.Models.Facilities;
namespace Partify.Web.WebServices.Facilities;

public class FacilityWebService(IFacilityService facilityService, IMapper mapper) : IFacilityWebService
{
    public async ValueTask<FacilityViewModel> CreateAsync(FacilityCreateModel createModel)
    {
        var createdFacility = await facilityService.CreateAsync(mapper.Map<Facility>(createModel));
        return mapper.Map<FacilityViewModel>(createdFacility);
    }

    public async ValueTask<bool> DeleteAsync(long id)
    {
        return await facilityService.DeleteAsync(id);
    }

    public async ValueTask<IEnumerable<FacilityViewModel>> GetAllAsync(
    PaginationParams @params,
    Filter filter,
        string search = null)
    {
        var result = await facilityService.GetAllAsync(@params, filter, search);
        return mapper.Map<IEnumerable<FacilityViewModel>>(result);
    }
    public async ValueTask<IEnumerable<FacilityViewModel>> GetAllAsync()
    {
        var result = await facilityService.GetAllAsync();
        return mapper.Map<IEnumerable<FacilityViewModel>>(result);
    }

    public async ValueTask<FacilityViewModel> GetByIdAsync(long id)
    {
        var result = await facilityService.GetByIdAsync(id);
        return mapper.Map<FacilityViewModel>(result);
    }

    public async ValueTask<FacilityViewModel> UpdateAsync(long id, FacilityUpdateModel updateModel)
    {
        var updatedFacility = await facilityService.UpdateAsync(id, mapper.Map<Facility>(updateModel));
        return mapper.Map<FacilityViewModel>(updatedFacility);
    }
}
