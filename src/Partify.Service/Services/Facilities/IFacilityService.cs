using Partify.Domain.Entities.Facilities;
using Partify.Service.Configurations;

namespace Partify.Service.Services.Facilities;

public interface IFacilityService
{
	ValueTask<Facility> CreateAsync(Facility facility);
	ValueTask<Facility> UpdateAsync(long id, Facility facility);
	ValueTask<bool> DeleteAsync(long id);
	ValueTask<Facility> GetByIdAsync(long id);
	ValueTask<IEnumerable<Facility>> GetAllAsync(PaginationParams @params, Filter filter, string search = null);
}