using Partify.Service.Configurations;
using Partify.WebApi.Models.Ads;

namespace Partify.WebApi.ApiServices.Ads
{
	public interface IAdApiService
	{
		ValueTask<AdViewModel> CreateAsync(AdCreateModel createModel);
		ValueTask<AdViewModel> UpdateAsync(long id, AdUpdateModel updateModel);
		ValueTask<bool> DeleteAsync(long id);
		ValueTask<AdViewModel> GetByIdAsync(long id);
		ValueTask<IEnumerable<AdViewModel>> GetAllAsync(PaginationParams @params, Filter filter, string search = null);
	}
}
