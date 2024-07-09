using Partify.Service.Configurations;
using Partify.WebApi.Models.Facilities;

namespace Partify.WebApi.ApiServices.Facilities;

public interface IFacilityApiService
{
	ValueTask<FacilityViewModel> CreateAsync(FacilityCreateModel createModel);
	ValueTask<FacilityViewModel> UpdateAsync(long id, FacilityUpdateModel updateModel);
	ValueTask<bool> DeleteAsync(long id);
	ValueTask<FacilityViewModel> GetByIdAsync(long id);
	ValueTask<IEnumerable<FacilityViewModel>> GetAllAsync(PaginationParams @params, Filter filter, string search = null);
}
