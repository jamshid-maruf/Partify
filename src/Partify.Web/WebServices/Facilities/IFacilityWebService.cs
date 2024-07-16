using Partify.Service.Configurations;
using Partify.Web.Models.Facilities;

namespace Partify.Web.WebServices.Facilities;

public interface IFacilityWebService
{
    ValueTask<FacilityViewModel> CreateAsync(FacilityCreateModel createModel);
    ValueTask<FacilityViewModel> UpdateAsync(long id, FacilityUpdateModel updateModel);
    ValueTask<bool> DeleteAsync(long id);
    ValueTask<FacilityViewModel> GetByIdAsync(long id);
    ValueTask<IEnumerable<FacilityViewModel>> GetAllAsync(PaginationParams @params, Filter filter, string search = null);
    ValueTask<IEnumerable<FacilityViewModel>> GetAllAsync();
}

